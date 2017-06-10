//////////////////////////////////////////////////////////////////////////////////////////////////
//				  Support_RaycastingWeapons.cs  				//
//Creator: Space Guy, Iban									//
//Allows you to create weapons that function by instant raycasts rather than projectiles	//
//Set these fields in the datablock:								//
//raycastWeaponRange:		Range of weapon	(> 0)						//
//raycastWeaponTargets:		Typemasks							//
//raycastWeaponPierceTargets:	Typemasks (weapon fires through these targets, hitting each)	//
//raycastDirectDamage:		Direct Damage							//
//raycastDirectDamageType:	Damage Type ID							//
//raycastCritDirectDamageType:	Critical Hit Damage Type ID					//
//raycastExplosionProjectile:	Creates this projectile on impact				//
//raycastExplosionSound:	AudioProfile of sound to play on impact				//
//raycastExplosionPlayerSound:	AudioProfile of sound to play on hitting a player		//
//raycastExplosionBrickSound:	AudioProfile of sound to play on hitting a brick		//
//raycastExplosionCritSound:	AudioProfile of sound to play a critical impact			//
//raycastSpreadAmt:		Spread radius of weapon						//
//raycastSpreadCount:		Number of spreading projectiles					//
//raycastTracerProjectile:	Fires tracer projectiles along the spread path			//
//raycastCritTracerProjectile:	Fires tracer projectiles along the spread path if critical hit	//
//raycastFromMuzzle:	Fire from muzzle point to muzzle vector instead of eye			//
//												//
//Radius and Brick Damage can be done through the projectile and explosion.			//
//////////////////////////////////////////////////////////////////////////////////////////////////
exec("./Support_FractionRayCast.cs");

if($SpaceMods::Server::RaycastingWeaponsVersion > 3)
	return;

$SpaceMods::Server::RaycastingWeaponsVersion = 3;

package RaycastingFire
{
	function WeaponImage::onFire(%this,%obj,%slot)
	{
		if(%this.raycastWeaponRange <= 0)
			return Parent::onFire(%this,%obj,%slot);
		
		%targets = %this.raycastWeaponTargets;
		%ptargets = %this.raycastWeaponPierceTargets;
		%hit = 0;
	  
	  %fromEye = checkForObstruction(%obj,%targets);
	  
		if(%this.raycastFromMuzzle && !%fromEye)
		{
			%start = %obj.getMuzzlePoint(0);
			%aimVec = %obj.getMuzzleVector(0);
		}
		else
		{
			%start = %obj.getEyePoint();
			
			%fvec = %obj.getForwardVector();
			%fX = getWord(%fvec,0);
			%fY = getWord(%fvec,1);
			
			%evec = %obj.getEyeVector();
			%eX = getWord(%evec,0);
			%eY = getWord(%evec,1);
			%eZ = getWord(%evec,2);
			
			%eXY = mSqrt(%eX*%eX+%eY*%eY);
			
			%aimVec = %fX*%eXY SPC %fY*%eXY SPC %eZ;
		}
		
		if(%this.raycastSpreadCount <= 0)
			%shellcount = 1;
		else
			%shellcount = %this.raycastSpreadCount;
		
		%fireCrit = 0;
		%critHit = 1;
		
		for(%i=0;%i<%shellcount;%i++)
		{
			%shellCrit = 0;
			
			if(%this.raycastSpreadAmt > 0)
			{
				%spread = %this.raycastSpreadAmt;
				
				%vector = VectorScale(%aimVec, 100);
				%x = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
				%y = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
				%z = (getRandom() - 0.5) * 10 * 3.1415926 * %spread;
				%mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
				%shotVec = vectorNormalize(MatrixMulVector(%mat, %vector));
			}
			else
				%shotVec = %aimVec;
			
			%range = %this.raycastWeaponRange*getWord(%obj.getScale(),2);
			//if(%range > 100)
			//{
			//  %rangeRem = %range - 100;
			//   %range = 100;
			//}
			
			%end = vectorAdd(%start,vectorScale(%shotVec,%range));
			%pos = %end;
		  
			%ray = containerRayCast(%start, %end, %targets, %obj);
			%col = getWord(%ray,0);
			if(isObject(%col))
			{
				%colType = %col.getType();
				%pos = posFromRaycast(%ray);
				%normal = normalFromRaycast(%ray);
				%end = %pos;
				%hit++;
				
				%crit = 0;
				if(isObject(CritProjectile))
				{
					if(%this.isRaycastCritical(%obj, %slot, %col, %pos, %normal, %hit))
					{
						%crit = 1;
						%shellCrit = 1;
						%fireCrit = 1;
					}
				}
				
				%this.onHitObject(%obj, %slot, %col, %pos, %normal, %shotVec, %crit);
				
				if(%colType & %ptargets)
				{
					%rangeRem = %rangeRem + vectorLen(vectorSub(%pos,%start)) - 1;
					%end = vectorAdd(%end,vectorScale(%shotVec,1));
				}
				else
					%rangeRem = 0;
			}
			else
			{
				//%rangeRem = %rangeRem - 100;
				%crit = 0;
				if(isObject(CritProjectile))
				{
					if(%this.isRaycastCritical(%obj, %slot, -1, "0 0 0", "0 0 1", %hit))
					{
						%crit = 1;
						%shellCrit = 1;
						%fireCrit = 1;
					}
				}
			}
			
			while(%rangeRem > 0)
			{
				%count++;
				
				%range = %rangeRem;
				//if(%range >= 100)
				//{
				//   %rangeRem = %range - 100;
				//   %range = 100;
				//}
				
				%point = %end;
				%end = vectorAdd(%point,vectorScale(%shotVec,%range));
				%ray = containerRayCast(%point, %end, %targets, %obj);
				%col = getWord(%ray,0);
				
				if(isObject(%col))
				{
					%colType = %col.getType();
					%pos = posFromRaycast(%ray);
					%normal = normalFromRaycast(%ray);
					%end = %pos;
					%hit++;
					
					%crit = 0;
					if(isObject(CritProjectile))
					{
						if(%this.isRaycastCritical(%obj, %slot, %col, %pos, %normal, %hit))
						{
							%crit = 1;
							%critHit = 1;
							%shellCrit = 1;
							%fireCrit = 1;
						}
					}
					
					%this.onHitObject(%obj, %slot, %col, %pos, %normal, %shotVec, %crit);
					
					if(%colType & %ptargets)
					{
						%rangeRem = %rangeRem + vectorLen(vectorSub(%pos,%point)) - 1;
						%end = vectorAdd(%end,vectorScale(%shotVec,1));
					}
					else
						%rangeRem = 0;
				}
				else
				{
					%crit = 0;
					if(isObject(CritProjectile))
					{
						if(%this.isRaycastCritical(%obj, %slot, -1, "0 0 0", "0 0 1", %hit))
						{
							%crit = 1;
							%shellCrit = 1;
							%fireCrit = 1;
						}
					}
				}
			}
			
			if(isObject(%this.raycastTracerProjectile))
			{
				%projectile = %this.raycastTracerProjectile;
				if(%shellCrit && isObject(%this.raycastCritTracerProjectile))
					%projectile = %this.raycastCritTracerProjectile;
				
				%muzzle = %obj.getMuzzlePoint(%slot);
				%scaleFactor = getWord(%obj.getScale(),2);
				
				%p = new (%this.projectileType)()
				{
					dataBlock = %projectile;
					initialVelocity = vectorScale(vectorNormalize(vectorSub(%end,%muzzle)),%projectile.muzzleVelocity);
					initialPosition = %muzzle;
					sourceObject = %obj;
					sourceSlot = %slot;
					client = %obj.client;
				};
				%p.setScale(%scaleFactor SPC %scaleFactor SPC %scaleFactor);
				MissionCleanup.add(%p);
			}
			if(isObject(%this.raycastTracerShape))
			{
				%size = %this.raycastTracerSize;
				%color = %this.raycastTracerColor;
				if(%size <= 0)
				{
					%size = 1;
				}
				if(%color <= 0)
				{
					%color = "1 1 1 1";
				}

				%a = %obj.getMuzzlePoint(0);
				%b = %end;
				%shape = createTracer( %this.raycastTracerShape, %a, %b, %size, %color );

				%shape.schedule(16, playThread, 0, %shape.dataBlock.Thread);
				%shape.schedule(64, delete);
			}
		}
		
		if(%obj.getType() & $TypeMasks::PlayerObjectType && %fireCrit)
		{
			serverplay3d(critFireSound,%obj.getHackPosition());
			if(isObject(%obj.client) && %critHit)
				%obj.client.play2d(critHitSound);
		}
	}
	function disconnect()
	{
		Parent::disconnect();
		$SpaceMods::Server::RaycastingWeaponsVersion = -1;
		schedule(10, 0, deActivatePackage, RaycastingFire); //we probably don't want to de-activate a package while we're in it, so schedule it 
	}
};activatePackage(RaycastingFire);

function WeaponImage::onHitObject(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
{
	if(!isObject(%col))
		return;
	
	%colType = %col.getType(); //%col changes to CorpseObjectType if you kill a player 
	
	if(!isObject(CritProjectile))
		%crit = 0;
	
	if(%this.raycastDirectDamage > 0 && %colType & ($TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType))
	{
		if(isObject(%col.spawnBrick) && %col.spawnBrick.getGroup().client == %obj.client)
			%dmg = 1;
		if(miniGameCanDamage(%obj,%col) == 1 || %dmg)
			%this.onRaycastDamage(%obj,%slot,%col,%pos,%normal,%shotVec,%crit);
	}
	
	if(isObject(%this.raycastExplosionProjectile))
	{
		%scaleFactor = getWord(%obj.getScale(), 2);
		%p = new Projectile()
		{
			dataBlock = %this.raycastExplosionProjectile;
			initialPosition = %pos;
			initialVelocity = %normal;
			sourceObject = %obj;
			client = %obj.client;
			sourceSlot = 0;
			originPoint = %pos;
		};
		MissionCleanup.add(%p);
		%p.setScale(%scaleFactor SPC %scaleFactor SPC %scaleFactor);
		%p.explode();
	}
	
	if(isObject(%this.raycastExplosionSound))
		serverplay3d(%this.raycastExplosionSound,%pos);
	
	if(isObject(%this.raycastExplosionCritSound) && %crit)
		serverplay3d(%this.raycastExplosionCritSound,%pos);
	
	%colPlayer = (%colType & $TypeMasks::PlayerObjectType);
	
	if(%colPlayer && isObject(%this.raycastExplosionPlayerSound))
		serverplay3d(%this.raycastExplosionPlayerSound,%pos);
	else if(!%colPlayer && isObject(%this.raycastExplosionBrickSound))
		serverplay3d(%this.raycastExplosionBrickSound,%pos);
}

function WeaponImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
{
	%damageType = $DamageType::Direct;
	if(%this.raycastDirectDamageType)
		%damageType = %this.raycastDirectDamageType;
	
	%scale = getWord(%obj.getScale(), 2);
	%directDamage = mClampF(%this.raycastDirectDamage, -100, 100) * %scale;
	
	// CALL DEM HITMARKERSSSSSSSS
	commandToClient(%obj.client,'hitmarker');
	
	if(%crit)
	{
		if(%this.raycastCritDirectDamageType)
			%damageType = %this.raycastCritDirectDamageType;
		
		%directDamage = %directDamage * 3;
		
		%colscale = getWord(%col.getScale(),2);
		%col.spawnExplosion(critProjectile,%colscale);
		if(isObject(%col.client))
			%col.client.play2d(critRecieveSound);
	}
	
	if(%this.raycastImpactImpulse > 0)
		%col.applyImpulse(%pos,vectorScale(%shotVec,%this.raycastImpactImpulse));
	
	if(%this.raycastVerticalImpulse > 0)
		%col.applyImpulse(%pos,vectorScale("0 0 1",%this.raycastVerticalImpulse));
	
	%col.damage(%obj, %pos, %directDamage, %damageType);
}

function WeaponImage::isRaycastCritical(%this,%obj,%slot,%col,%pos,%normal,%hit)
{
	return 0;
}

function checkForObstruction(%obj,%targets)
{
	%start = %obj.getEyePoint();
	
	%fvec = %obj.getForwardVector();
	%fX = getWord(%fvec,0);
	%fY = getWord(%fvec,1);
	
	%evec = %obj.getEyeVector();
	%eX = getWord(%evec,0);
	%eY = getWord(%evec,1);
	%eZ = getWord(%evec,2);
	
	%eXY = mSqrt(%eX*%eX+%eY*%eY);
	
	%eyeVector = %fX*%eXY SPC %fY*%eXY SPC %eZ;
	
	%range = vectorAdd(%start,vectorScale(%eyeVector,4.5));
	%raycast = containerRayCast(%start,%range,%targets,%obj);
	return isObject(firstWord(%raycast));
}

function createTracer( %datablock, %a, %b, %size, %color )
{
	if ( !strLen( %size ) )
	{
		%size = 0.05;
	}

	if ( !strLen( %color ) )
	{
		%color = "1 1 1 1";
	}

	%offset = vectorSub( %a, %b );
	%normal = vectorNormalize( %offset );

	%xyz = vectorNormalize( vectorCross( "1 0 0", %normal ) );
	%pow = mRadToDeg( mACos( vectorDot( "1 0 0", %normal ) ) ) * -1;

	%obj = new staticShape()
	{
		a = %a;
		b = %b;

		datablock = %datablock;
		scale = vectorLen( %offset ) * 2 SPC %size SPC %size;

		position = vectorScale( vectorAdd( %a, %b ), 0.5 );
		rotation = %xyz SPC %pow;
	};

	missionCleanup.add( %obj );
	%obj.setNodeColor( "ALL", %color );

	return %obj;
}