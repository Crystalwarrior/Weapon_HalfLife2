//	+-----------------------------------+
//	|		HL2 Weapons Pack			|
//	|		by Zapk & Aware14			|
//	+-----------------------------------+
//	|		hl2SMG.cs						|
//	+-----------------------------------+

//audio
datablock AudioProfile(hl2SMGfireSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/SMG/smg_fire.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2SMGgrenadeExplosionSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Grenade/GrenadeExplode.wav";
	description = AudioClose3d;
	preload     = false;
};
datablock AudioProfile(hl2SMGgrenadeFireSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/SMG/grenade.wav";
	description = AudioClosest3d;
	preload     = true;
};
datablock AudioProfile(hl2SMGReloadSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/SMG/smg_reload.wav";
	description = AudioClosest3d;
	preload     = true;
};

datablock ParticleData(hl2SMGgrenadeFireParticle)
{
	dragCoefficient      = 3;
	gravityCoefficient   = -1;
	inheritedVelFactor   = 1;
	constantAcceleration = 0.0;
	lifetimeMS           = 1000;
	lifetimeVarianceMS   = 500;
	textureName          = "base/data/particles/cloud";
	spinSpeed		      = 10.0;
	spinRandomMin		   = -150.0;
	spinRandomMax	   	= 150.0;
	colors[0]     = "1 0.5 0 0.4";
	colors[1]     = "1 0.2 0 0.3";
	colors[2]     = "1 0 0 0";
	sizes[0]      = 0.5;
	sizes[1]      = 0.35;
	sizes[2]      = 0.25;
	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2SMGgrenadeFireEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 0.25;
	velocityVariance = 0.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2SMGgrenadeFireParticle";
};

datablock DebrisData(hl2SMGgrenadeDebris)
{
	emitters = "hl2SMGgrenadeFireEmitter";

	shapeFile = "base/data/shapes/empty.dts";
	lifetime = 0.8;
	lifetimeVariance = 0.3;
	minSpinSpeed = 0;
	maxSpinSpeed = 1;
	elasticity = 0.3;
	friction = 0.2;
	numBounces = 5;
	staticOnMaxBounce = true;
	fade = true;
	gravModifier = 2;
};

datablock ParticleData(hl2SMGgrenadeTrailParticle)
{
	dragCoefficient		= 3.0;
	windCoefficient		= 0.0;
	gravityCoefficient	= 0.0;
	inheritedVelFactor	= 0.0;
	constantAcceleration	= 0.0;
	lifetimeMS		= 600;
	lifetimeVarianceMS	= 0;
	spinSpeed		= 10.0;
	spinRandomMin		= -50.0;
	spinRandomMax		= 50.0;
	useInvAlpha		= true;
	animateTexture		= false;
	textureName	= "base/data/particles/thinring";
	colors[0]	= "0.75 0.75 0.75 0.9";
	colors[1]	= "0.75 0.75 0.75 0.4";
	colors[2]	= "1 1 1 0.0";
	sizes[0]	= 0.15;
	sizes[1]	= 0.25;
	sizes[2]	= 0.05;
	times[0]	= 0.0;
	times[1]	= 0.1;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(hl2SMGgrenadeTrailEmitter)
{
	ejectionPeriodMS = 15;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	ejectionOffset = 0;
	thetaMin         = 0.0;
	thetaMax         = 90.0;  
	particles = hl2SMGgrenadeTrailParticle;
};

datablock ExplosionData(hl2SMGgrenadeExplosion : hl2GrenadeExplosion)
{
	soundProfile = hl2SMGGrenadeExplosionSound;

	impulseRadius = 9;
	impulseForce = 1000;

	radiusDamage = 150;
	damageRadius = 8;

	emitter[0] = hl2GrenadeExplosionEmitter3;
	emitter[1] = hl2GrenadeExplosionEmitter2;
	emitter[2] = hl2GrenadeExplosionEmitter4;

	particleEmitter = hl2GrenadeExplosionEmitter;
};

//projectile
AddDamageType("hl2SMGgrenadeRadius",'<bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_SMGgrenade> %1',    '%2 <bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_SMGgrenade> %1',0.5,1);

datablock ProjectileData(hl2SMGgrenadeProjectile)
{
	projectileShapeName = $hl2Weapons::Path @ "/Models/mp7grenade.dts";
	directDamage        = 100;
	directDamageType  = $DamageType::hl2SMGgrenadeRadius;
	radiusDamageType  = $DamageType::hl2SMGgrenadeRadius;
	impactImpulse	   = 500;
	verticalImpulse	  = 300;
	impactImpulse     = 200;
	verticalImpulse      = 200;
	explosion           = hl2SMGGrenadeExplosion;
	particleEmitter     = hl2SMGgrenadeTrailEmitter;

	brickExplosionRadius = 10;
	brickExplosionImpact = false; //destroy a brick if we hit it directly?

	muzzleVelocity      = 30;
	velInhl2GrenaderitFactor    = 0;
	explodeOnDeath = true;

	armingDelay         = 0; 
	lifetime            = 5000;
	fadeDelay           = 4500;
	bounceElasticity    = 0.4;
	bounceFriction      = 0.3;
	isBallistic         = true;
	gravityMod = 1.0;

	hasLight    = false;
};

AddDamageType("hl2SMG",   '<bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_SMG> %1',    '%2 <bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_SMG> %1',0.5,1);
datablock ProjectileData(hl2SMGProjectile)
{
	projectileShapeName = "Add-Ons/Weapon_Gun/bullet.dts";
	directDamage        = 0;
	directDamageType    = $DamageType::hl2SMG;
	radiusDamageType    = $DamageType::hl2SMG;

	brickExplosionRadius = 0;
	brickExplosionImpact = true;
	brickExplosionForce  = 10;
	brickExplosionMaxVolume = 1;  
	brickExplosionMaxVolumeFloating = 1; 

	impactImpulse	     = 0;
	verticalImpulse	  = 0;
	explosion           = hl2PistolExplosion;

	muzzleVelocity      = 200;
	velInheritFactor    = 1;

	armingDelay         = 00;
	lifetime            = 700;
	fadeDelay           = 500;
	bounceElasticity    = 0.5;
	bounceFriction      = 0.20;
	isBallistic         = false;
	gravityMod = 0.0;

	hasLight    = false;
	lightRadius = 3.0;
	lightColor  = "0 0 0.5";
};

datablock ProjectileData(hl2SMGTracerProjectile)
{
	projectileShapeName = $hl2Weapons::Path @ "/Models/bullet_9mm.dts";
	directDamage        = 0;
	muzzleVelocity      = 200;
	velInheritFactor    = 1;
	lifetime            = 200;
	fadeDelay           = 100;
};

datablock ItemData(hl2SMGItem)
{
	category = "Weapon"; 
	className = "Weapon";

	shapeFile = $hl2Weapons::Path @ "/Models/hl2_smg.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	uiName = "MP7 SMG";
	iconName = $hl2Weapons::Path @ "/Icons/Icon_SMG";
	doColorShift = false;
	colorShiftColor = "0.5 0.5 0.5 1.000";

	maxmag = 45;
	ammotype = "smg";
	reload = true;

	altmaxmag = 3;
	altammotype = "riflenade"; //for ammo item reference

	image = hl2SMGImage;
	canDrop = true;
};




datablock ShapeBaseImageData(hl2SMGImage)
{
	shapeFile = $hl2Weapons::Path @ "/Models/hl2_smg.dts";
	emap = true;
	
	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = 0; //"0.7 1.2 -0.5";
	rotation = eulerToMatrix( "0 0 0" );

	correctMuzzleVector = true;

	className = "WeaponImage";

	item = hl2SMGItem;
	ammo = " ";
	projectile = hl2SMGProjectile;
	projectileType = Projectile;

	raycastWeaponRange = 200;
	raycastWeaponTargets =
						 $TypeMasks::PlayerObjectType |    //AI/Players
						 $TypeMasks::StaticObjectType |    //Static Shapes
						 $TypeMasks::TerrainObjectType |    //Terrain
						 $TypeMasks::VehicleObjectType |    //Terrain
						 $TypeMasks::FXBrickObjectType;    //Bricks
	raycastExplosionProjectile = hl2SMGProjectile;
	raycastExplosionBrickSound = "";
	raycastExplosionPlayerSound = "";
	raycastDirectDamage = 5; //10
	raycastDirectDamageType = $DamageType::hl2SMG;
	raycastSpreadAmt = 0.001;
	raycastSpreadCount = 1;
	raycastTracerProjectile = hl2SMGTracerProjectile;
	raycastTracerShape = hl2TracerShapeData;
	raycastTracerSize = 1;
	raycastTracerColor = "0.8 0.5 0.0 1";
	raycastFromMuzzle = true;

	casing = hl2PistolShellDebris;
	shellExitDir        = "0 -0.1 -0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;	
	shellVelocity       = 7.0;

	melee = false;
	armReady = true;

	doColorShift = false;
	colorShiftColor = hl2SMGItem.colorShiftColor;

	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.15;
	stateTransitionOnTimeout[0]      = "AmmoCheck";
	stateSound[0]                    = "";

	stateName[1]                     = "Ready";
	stateTransitionOnTriggerDown[1]  = "Fire";
	stateTransitionOnNoAmmo[1]       = "Empty";
	stateAllowImageChange[1]         = true;
	stateSequence[1]                 = "idle";

	stateName[2]                     = "Fire";
	stateTransitionOnTimeOut[2]      = "AmmoCheck";
	stateSound[2]                    = hl2SMGFireSound;
	stateTimeoutValue[2]             = 0.07;
	stateFire[2]                     = true;
	stateAllowImageChange[2]         = false;
	stateSequence[2]                 = "Fire";
	stateScript[2]                   = "onFire";
	stateWaitForTimeout[2]           = true;
	stateEmitter[2]                  = hl2PistolFlashEmitter;
	stateEmitterTime[2]              = 0.05;
	stateEmitterNode[2]              = "muzzleNode";
	stateEjectShell[2]               = true;

	stateName[3]                     = "AmmoCheck";
	stateTransitionOnTimeout[3]      = "Ready";
	stateAllowImageChange[3]         = true;
	stateScript[3]                   = "onAmmoCheck";

	stateName[4]                     = "Reload";
	stateTransitionOnTimeout[4]      = "ReloadReady";
	stateTimeoutValue[4]             = 0.85;
	stateAllowImageChange[4]         = true;
	stateScript[4]                   = "onReloadStart";
	stateSequence[4]                 = "shiftLeft";
	stateSound[4]                    = hl2SMGReloadSound;

	stateName[5]                     = "ReloadReady";
	stateTransitionOnTimeout[5]      = "CheckChamber";
	stateTimeoutValue[5]             = 0.1;
	stateSequence[5]                 = "shiftRight";
	stateAllowImageChange[5]         = true;
	stateScript[5]                   = "onReload";

	stateName[6]                     = "Empty";
	stateTransitionOnTriggerDown[6]  = "EmptyFire";
	stateAllowImageChange[6]         = true;
	stateScript[6]                   = "onEmpty";
	stateTransitionOnAmmo[6]         = "Reload";
	stateSequence[6]                 = "idle";

	stateName[7]                     = "EmptyFire";
	stateTransitionOnTriggerUp[7]    = "Empty";
	stateTimeoutValue[7]             = 0.13;
	stateAllowImageChange[7]         = false;
	stateWaitForTimeout[7]           = true;
	stateSound[7]                    = hl2PistolEmptySound;
	stateSequence[7]                 = "empty";

	stateName[8]                     = "CheckChamber";
	stateTransitionOnTimeOut[8]      = "Ready";
	stateTransitionOnNoAmmo[8]       = "Cocking";
	stateAllowImageChange[8]         = true;
 
	stateName[9]                     = "Cocking";
	stateTransitionOnTimeOut[9]      = "Ready";
	stateTimeoutValue[9]             = 0.1;
	stateAllowImageChange[9]         = true;
	stateWaitForTimeout[9]           = true;
	stateSound[9]                    = "";
	stateScript[9]                   = "onCock";

};

function hl2SMGImage::onReloadStart( %this, %obj, %slot )
{
	%obj.playThread(2,shiftRight);
	%obj.schedule(500, "playThread", "2", "shiftRight");
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2SMGImage::onAmmoCheck( %this, %obj, %slot )
{
	hl2AmmoCheck(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2SMGImage::onReload( %this, %obj, %slot )
{
	%obj.playThread(2,plant);
	hl2AmmoOnReload(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2SMGImage::onCock( %this, %obj, %slot )
{
	%obj.playThread(2,shiftRight);
	%obj.setImageAmmo(0,1);
}

function hl2SMGImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,0);
}
function hl2SMGImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,-1);
}

function hl2SMGImage::onFire(%this,%obj,%slot)
{
	if(%obj.getDamagePercent() > 1.0)
	{
		return;
	}

	if($hl2Weapons::ammoSystem)
	{
		%obj.toolMag[%obj.currTool] -= 1;

		if(%obj.toolMag[%obj.currTool] < 1)
		{
			%obj.toolMag[%obj.currTool] = 0;
			%obj.setImageAmmo(0,0);
		}
		hl2DisplayAmmo(%this,%obj,%slot);
	}
	
	parent::onFire( %this, %obj, %slot );
	%obj.playThread(2, plant);
}

function hl2SMGImage::onEmpty(%this,%obj,%slot)
{
	if( $hl2Weapons::Ammo && %obj.toolAmmo[%this.item.ammotype] < 1 )
	{
		return;
	}

	if(%obj.toolMag[%obj.currTool] < 1)
	{
		serverCmdLight(%obj.client);
	}
}

function hl2SMGImage::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit )
{
	if( !( %col.getType() & $typeMasks::playerObjectType || %col.getType() & $typeMasks::corpseObjectType ) )
	{
		%rnd = getRandom( 1, 4 );
		serverPlay3d( hl2BulletHitSound @ %rnd, %pos );
	}
	else
	{
		%damage = %this.raycastDirectDamage;
		%headshot = matchBodyArea( getHitbox( %obj, %col, %pos ), $headTest );

		if ( %headshot )
		{
			%damage *= 3;
		}

		%rnd = getRandom( 1, 4 );
		serverPlay3d( hl2FleshHitSound @ %rnd, %pos );
	}

	if( !(%col.getType() & $typeMasks::playerObjectType) && !(%col.getType & $TypeMasks::vehicleObjectType) )
	{
		spawnDecal(gunShotShapeData, vectorAdd(%pos, vectorScale(%normal, 0.02)), %normal);
	}

	parent::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit );
}

function hl2SMGImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
{
	%damageType = $DamageType::Direct;
	if(%this.raycastDirectDamageType)
		%damageType = %this.raycastDirectDamageType;
	
	%scale = getWord(%obj.getScale(), 2);
	%damage = mClampF(%this.raycastDirectDamage, -100, 100) * %scale;

	%headshot = matchBodyArea( getHitbox( %obj, %col, %pos ), $headTest );

	if ( %headshot )
	{
		%damage *= 3;
	}
  
	if(%this.raycastImpactImpulse > 0)
		%col.applyImpulse(%pos,vectorScale(%shotVec,%this.raycastImpactImpulse));
	
	if(%this.raycastVerticalImpulse > 0)
		%col.applyImpulse(%pos,vectorScale("0 0 1",%this.raycastVerticalImpulse));
	
	%col.damage(%obj, %pos, %damage, %damageType);
}

package hl2SMG
{
	function Armor::onTrigger(%this, %obj, %slot, %val)
	{
		if(%obj.getMountedImage(0) $= hl2SMGImage.getID() && %slot $= 4 && %val)
		{
			if(%obj.getImageState(0) $= "Ready" || %obj.getImageState(0) $= "Empty")
			{
				%image = %obj.getMountedimage(0);
				if(%obj.toolAltMag[%obj.tool[%obj.currtool].altammotype] <= 0 || $Sim::Time - %obj.lastSMGNade < 1)
				{
					serverPlay3D(hl2PistolEmptySound,%obj.getPosition());
					return;
				}
				hl2DisplayAmmo(%this, %obj, %obj.currTool);
				%obj.unMountImage(0);
				%obj.mountImage(hl2SMGAltFireImage, 0);
				%obj.lastSMGNade = $Sim::Time;
			}
		}
		Parent::onTrigger(%this, %obj, %slot, %val);
	}
};   
ActivatePackage(hl2SMG);

datablock ShapeBaseImageData(hl2SMGAltFireImage : hl2SMGImage)
{
	projectile = hl2SMGgrenadeProjectile;
	raycastWeaponRange = "";

	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.01;
	stateTransitionOnTimeout[0]      = "Charge";
	stateSequence[0]            = "Root";
	stateSound[0]                    = "";

	stateName[1]                = "Charge";
	stateTimeoutValue[1]        = 0.01;
	stateTransitionOnTimeout[1]       = "Fire";
	stateWaitForTimeout[1]         = true;
	stateAllowImageChange[1]       = false;
	//stateSound[1]                    = hl2AR2ChargeSound;

	stateName[2]                     = "Fire";
	stateTransitionOnTimeOut[2]      = "Wait";
	stateSound[2]                    = hl2SMGgrenadeFireSound;
	stateTimeoutValue[2]             = 0.1;
	stateFire[2]                     = true;
	stateAllowImageChange[2]         = false;
	stateSequence[2]                 = "Fire";
	stateScript[2]                   = "onFire";
	stateWaitForTimeout[2]           = true;
	stateEmitter[2]                  = hl2AR2FlashEmitter;
	stateEmitterTime[2]              = 0.05;
	stateEmitterNode[2]              = "muzzleNode";
	stateEjectShell[2]               = true;

	stateName[3]                = "Wait";
	stateTransitionOnTimeout[3]       = "Done";
	stateAllowImageChange[3]       = false;
	stateTimeoutValue[3]        = 0.14;

	stateName[4]                = "Done";
	stateAllowImageChange[4]       = true;
	stateSequence[4]            = "Ready";
	stateScript[4]              = "onDone";
};

function hl2SMGAltFireImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,0);
}
function hl2SMGAltFireImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,-1);
}

function hl2SMGAltFireImage::onFire(%this, %obj, %slot)
{
	parent::onFire(%this, %obj, %slot);
	%obj.playThread(2, jump);
	%obj.toolAltMag[%obj.tool[%obj.currtool].altammotype]--;
	hl2DisplayAmmo(%this, %obj, %slot);
}

function hl2SMGAltFireImage::onDone(%this, %obj, %slot)
{
	%obj.mountImage(hl2SMGImage, 0);
}
