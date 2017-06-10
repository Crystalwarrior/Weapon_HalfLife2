//	+-----------------------------------+
//	|		Half-life2 Weapons Pack         |
//  |   by Jack Noir                    |
//	|		Placeholder models by           |
//  |       Zapk & Aware14              |
//	+-----------------------------------+
//	|		Shotgun.cs					            |
//	+-----------------------------------+

//audio
datablock AudioProfile(hl2ShotgunReloadSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Shotgun/ShotgunReload.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2ShotgunShellSound1)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Shotgun/shotgun_reload1.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2ShotgunShellSound2)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Shotgun/shotgun_reload2.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2ShotgunShellSound3)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Shotgun/shotgun_reload3.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2ShotgunFireSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Shotgun/ShotgunFire.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2ShotgunAltFireSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Shotgun/shotgun_dbl_fire.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2ShotgunEmptySound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Shotgun/shotgun_empty.wav";
	description = AudioClose3d;
	preload = true;
};

datablock DebrisData(hl2ShotgunShellDebris)
{
	shapeFile = $hl2Weapons::Path @ "/Models/shell_buckshot.dts";
	lifetime = 6.0;
	minSpinSpeed = -400.0;
	maxSpinSpeed = 200.0;
	elasticity = 0.5;
	friction = 0.2;
	numBounces = 3;
	staticOnMaxBounce = true;
	snapOnMaxBounce = false;
	fade = true;

	gravModifier = 2;
};

//emitter
datablock ParticleData(hl2ShotgunSmokeParticle)
{
	dragCoefficient      = 3;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 525;
	lifetimeVarianceMS   = 55;
	textureName          = "base/data/particles/cloud";
	spinSpeed		= 10.0;
	spinRandomMin		= -500.0;
	spinRandomMax		= 500.0;
	colors[0]     = "0.5 0.5 0.5 0.5";
	colors[1]     = "0.5 0.5 0.5 0.0";
	sizes[0]      = 0.15;
	sizes[1]      = 0.1;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2ShotgunSmokeEmitter)
{
	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 1.0;
	velocityVariance = 1.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2ShotgunSmokeParticle";
};

AddDamageType("hl2Shotgun",   '<bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Shotgun> %1',    '%2 <bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Shotgun> %1',0.5,1);
datablock ProjectileData(hl2ShotgunProjectile)
{
	projectileShapeName = "add-ons/Weapon_Gun/bullet.dts";
	directDamage        = 0;
	directDamageType    = $DamageType::hl2Shotgun;
	radiusDamageType    = $DamageType::hl2Shotgun;

	brickExplosionRadius = 0;
	brickExplosionImpact = true;          //destroy a brick if we hit it directly?
	brickExplosionForce  = 5;
	brickExplosionMaxVolume = 2;          //max volume of bricks that we can destroy
	brickExplosionMaxVolumeFloating = 3;  //max volume of bricks that we can destroy if they aren't connected to the ground

	impactImpulse	     = 100;
	verticalImpulse     = 100;
	explosion           = hl2PistolExplosion;

	muzzleVelocity      = 150;
	velInheritFactor    = 1;

	armingDelay         = 0;
	lifetime            = 4000;
	fadeDelay           = 3500;
	bounceElasticity    = 0.5;
	bounceFriction      = 0.20;
	isBallistic         = false;
	gravityMod = 0.0;

	hasLight    = false;
	lightRadius = 3.0;
	lightColor  = "0 0 0.5";
};

datablock ProjectileData(hl2ShotgunTracerProjectile)
{
	projectileShapeName = $hl2Weapons::Path @ "/Models/bullet_buckshot.dts";
	directDamage        = 0;//75;
	muzzleVelocity      = 200;
	velInheritFactor    = 1;
	lifetime            = 200;
	fadeDelay           = 100;
};

//////////
// item //
//////////
datablock ItemData(hl2ShotgunItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = $hl2Weapons::Path @ "/Models/hl2_shotgun.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "SPAS-12 Shotgun";
	iconName = $hl2Weapons::Path @ "/Icons/Icon_Shotgun";
	doColorShift = true;
	colorShiftColor = "0.5 0.5 0.5 1.000";

	maxmag = 6;
	ammotype = "buckshot";
	reload = true;

	 // Dynamic properties defined by the scripts
	image = hl2ShotgunImage;
	canDrop = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(hl2ShotgunImage)
{
	// Basic Item properties
	shapeFile = $hl2Weapons::Path @ "/Models/hl2_shotgun.dts";
	emap = true;

	// Specify mount point & offset for 3rd person, and eye offset
	// for first person rendering.
	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = 0; //"0.7 1.2 -0.5";
	rotation = eulerToMatrix( "0 0 0" );

	// When firing from a point offset from the eye, muzzle correction
	// will adjust the muzzle vector to point to the eye LOS point.
	// Since this weapon doesn't actually fire from the muzzle point,
	// we need to turn this off.  
	correctMuzzleVector = true;

	// Add the WeaponImage namespace as a parent, WeaponImage namespace
	// provides some hooks into the inventory system.
	className = "WeaponImage";

	// Projectile && Ammo.
	item = hl2ShotgunItem;
	ammo = " ";
	projectile = hl2ShotgunProjectile;
	projectileType = Projectile;

	//melee particles shoot from eye node for consistancy
	melee = false;
	//raise your arm up or not
	armReady = true;
	minShotTime = 1000;

	raycastWeaponRange = 100;
	raycastWeaponTargets =
						 $TypeMasks::PlayerObjectType |    //AI/Players
						 $TypeMasks::StaticObjectType |    //Static Shapes
						 $TypeMasks::TerrainObjectType |    //Terrain
						 $TypeMasks::VehicleObjectType |    //Terrain
						 $TypeMasks::FXBrickObjectType;    //Bricks
	raycastExplosionProjectile = hl2ShotgunProjectile;
	raycastExplosionBrickSound = "";
	raycastExplosionPlayerSound = "";
	raycastDirectDamage = 9; //10
	raycastDirectDamageType = $DamageType::hl2Shotgun;
	raycastSpreadAmt = 0.004;
	raycastSpreadCount = 7;
	raycastTracerProjectile = hl2ShotgunTracerProjectile;
	raycastTracerShape = hl2TracerShapeData;
	raycastTracerSize = 1;
	raycastTracerColor = "0.8 0.5 0.0 1";
	raycastFromMuzzle = true;

	casing = hl2ShotgunShellDebris;
	shellExitDir        = "0.5 -1.3 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;   
	shellVelocity       = 7.0;

	doColorShift = true;
	colorShiftColor = hl2ShotgunItem.colorShiftColor;

	// Images have a state system which controls how the animations
	// are run, which sounds are played, script callbacks, etc. This
	// state system is downloaded to the client so that clients can
	// predict state changes and animate accordingly.  The following
	// system supports basic ready->fire->reload transitions as
	// well as a no-ammo->dryfire idle state.

	// Initial start up state
	stateName[0]                    = "Activate";
	stateTimeoutValue[0]            = 0.15;
	stateTransitionOnTimeout[0]     = "AmmoCheck";

	stateName[1]                    = "Ready";
	stateTransitionOnTriggerDown[1] = "Fire";
	stateTransitionOnNoAmmo[1]      = "Empty";
	stateAllowImageChange[1]        = true;
	stateTimeoutValue[1]		        = 0.01;

	stateName[2]                    = "Fire";
	stateTransitionOnTriggerUp[2]   = "CockAmmo";
	stateTimeoutValue[2]            = 0.4;
	stateFire[2]                    = true;
	stateAllowImageChange[2]        = false;
	stateSequence[2]                = "Fire";
	stateScript[2]                  = "onFire";
	stateWaitForTimeout[2]		     = true;
	stateEmitter[2]			        = hl2PistolFlashEmitter;
	stateEmitterTime[2]		        = 0.05;
	stateEmitterNode[2]		        = "muzzleNode";
	stateSound[2]			           = hl2ShotgunFireSound;

	stateName[3]                     = "AmmoCheck";
	stateTransitionOnTimeout[3]      = "Ready";
	stateAllowImageChange[3]         = true;
	stateScript[3]                   = "onAmmoCheck";

	stateName[4]			           = "Cocking";
	stateTimeoutValue[4]		        = 0.3;
	stateSequence[4]			        = "cock";
	stateTransitionOnTimeout[4]	  = "Wait";
	stateScript[4]                  = "onCock";
	stateWaitForTimeout[4]		     = true;
	stateEjectShell[4]       	     = true;
	stateSound[4]                   = hl2ShotgunReloadSound;

	stateName[5]                    = "CockAmmo";
	stateTimeoutValue[5]            = 0.3;
	stateSequence[5]                = "cock";
	stateTransitionOnTimeout[5]     = "Wait";
	statescript[5]                  = "onCockAmmo";
	stateWaitForTimeout[5]          = true;
	stateEjectShell[5]              = true;
	stateSound[5]                   = hl2ShotgunReloadSound;

	stateName[6]                    = "Reload";
	stateTimeoutValue[6]		        = 0.1;
	stateTransitionOnTriggerDown[6] = "Cocking";
	stateScript[6]                  = "onReloadSingle";
	stateTransitionOnTimeout[6]	  = "Wait2";

	stateName[7]                     = "CheckChamber";
	stateTransitionOnTriggerDown[7]  = "Cocking";
	stateTransitionOnTimeout[7]      = "Reload";
	stateTransitionOnAmmo[7]         = "AmmoCheck";
	stateScript[7]                   = "onCheckChamber";
	stateAllowImageChange[7]         = false;
	stateWaitForTimeout[7]           = true;

	stateName[8]                     = "Empty";
	stateTransitionOnTriggerDown[8]  = "EmptyFire";
	stateAllowImageChange[8]         = true;
	stateScript[8]                   = "onEmpty";
	stateTransitionOnAmmo[8]         = "Reload";

	stateName[9]                     = "EmptyFire";
	stateSound[9]                    = hl2ShotgunEmptySound;
	stateTransitionOnTriggerUp[9]    = "Empty";
	stateSequence[9]                 = "empty";
	stateTimeoutValue[9]             = 0.13;
	stateAllowImageChange[9]         = false;
	stateWaitForTimeout[9]           = true;

	stateName[10]                    = "Wait";
	stateTimeoutValue[10]            = 0.3;
	stateTransitionOnTimeout[10]     = "AmmoCheck";
	stateWaitForTimeout[10]         = true;

	stateName[11]                    = "Wait2";
	stateTimeoutValue[11]            = 0.3;
	stateTransitionOnTimeout[11]     = "CheckChamber";
	stateWaitForTimeout[11]          = true;
};

function hl2ShotgunImage::onReloadSingle( %this, %obj, %slot )
{
	%obj.playThread(2,shiftRight);
	%rnd = getRandom(1, 3);
	serverPlay3d( hl2ShotgunShellSound @ %rnd, %obj.getHackPosition() );
	hl2DisplayAmmo(%this,%obj,%slot);
	hl2AmmoOnReloadSingle(%this,%obj,%slot);
}

function hl2ShotgunImage::onAmmoCheck( %this, %obj, %slot )
{
	hl2AmmoCheck(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2ShotgunImage::onCheckChamber( %this, %obj, %slot )
{
	if(%obj.toolMag[%obj.currTool] > %this.item.maxmag)
	{
		%obj.toolMag[%obj.currTool] = %this.item.maxmag;
		%obj.setImageAmmo(0,1);
	}
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2ShotgunImage::onCock( %this, %obj, %slot )
{
	%obj.playThread(2,plant);
	%obj.setImageAmmo(0,1);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2ShotgunImage::onCockAmmo( %this, %obj, %slot )
{
	%obj.playThread(2,plant);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2ShotgunImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,0);
}
function hl2ShotgunImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,-1);
}

function hl2ShotgunImage::onEmpty(%this,%obj,%slot)
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

function hl2ShotgunImage::onFire(%this,%obj,%slot)
{
	echo($Sim::Time - %obj.lastFireTime);
	if($Sim::Time - %obj.lastFireTime <= 1)
	{
		return;
	}

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

	parent::onFire(%this, %obj, %slot);
	%obj.lastFireTime = $Sim::Time;
	// %obj.setVelocity(VectorAdd(%obj.getVelocity(),VectorScale(%obj.client.player.getEyeVector(),"-3")));
	%obj.playThread(2, shiftAway);
	%obj.playThread(3, jump);
}

function hl2ShotgunImage::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit )
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
		spawnDecal(gunShotShapeData, vectorAdd(%pos, vectorScale(%normal, 0.02)), %normal, 1);
	}
	
	parent::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit );
}

function hl2ShotgunImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
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

package hl2Shotgun
{
	function Armor::onTrigger(%this, %obj, %slot, %val)
	{
		if(%obj.getMountedImage(0) $= hl2ShotgunImage.getID() && %slot $= 4 && %val)
		{
			if(%obj.getImageState(0) $= "Ready" && %obj.getImageAmmo(0) == 1)
			{
				%image = %obj.getMountedimage(0);
				if($hl2Weapons::ammoSystem && %obj.toolMag[%obj.currTool] < 2)
				{
					serverPlay3D(hl2ShotgunEmptySound,%obj.getHackPosition());
					return;
				}
				%obj.toolMag[%obj.currTool] -= 2;
				hl2DisplayAmmo(%this, %obj, %obj.currTool);
				%obj.unMountImage(0);
				%obj.mountImage(hl2ShotgunAltFireImage, 0);
			}
			else
			{
				serverPlay3D(hl2ShotgunEmptySound,%obj.getHackPosition());
			}
		}
		Parent::onTrigger(%this, %obj, %slot, %val);
	}
};   
ActivatePackage(hl2Shotgun);

datablock ShapeBaseImageData(hl2ShotgunAltFireImage)
{
	// Basic Item properties
	shapeFile = $hl2Weapons::Path @ "/Models/hl2_shotgun.dts";
	emap = true;

	// Specify mount point & offset for 3rd person, and eye offset
	// for first person rendering.
	mountPoint = 0;
	offset = "0 0 0";
	eyeOffset = 0; //"0.7 1.2 -0.5";
	rotation = eulerToMatrix( "0 0 0" );

	// When firing from a point offset from the eye, muzzle correction
	// will adjust the muzzle vector to point to the eye LOS point.
	// Since this weapon doesn't actually fire from the muzzle point,
	// we need to turn this off.  
	correctMuzzleVector = true;

	// Add the WeaponImage namespace as a parent, WeaponImage namespace
	// provides some hooks into the inventory system.
	className = "WeaponImage";

	// Projectile && Ammo.
	item = hl2ShotgunItem;
	ammo = " ";
	projectile = hl2ShotgunProjectile;
	projectileType = Projectile;

	//melee particles shoot from eye node for consistancy
	melee = false;
	//raise your arm up or not
	armReady = true;
	minShotTime = 0;

	raycastWeaponRange = 80;
	raycastWeaponTargets =
						 $TypeMasks::PlayerObjectType |    //AI/Players
						 $TypeMasks::StaticObjectType |    //Static Shapes
						 $TypeMasks::TerrainObjectType |    //Terrain
						 $TypeMasks::VehicleObjectType |    //Terrain
						 $TypeMasks::FXBrickObjectType;    //Bricks
	raycastExplosionProjectile = hl2ShotgunProjectile;
	raycastExplosionBrickSound = "";
	raycastExplosionPlayerSound = "";
	raycastDirectDamage = 9; //10
	raycastDirectDamageType = $DamageType::hl2Shotgun;
	raycastSpreadAmt = 0.008;
	raycastSpreadCount = 12;
	raycastTracerProjectile = hl2ShotgunTracerProjectile;
	raycastTracerShape = hl2TracerShapeData;
	raycastTracerSize = 1;
	raycastTracerColor = "0.68 0.68 0.18 1";
	raycastFromMuzzle = true;

	casing = hl2ShotgunShellDebris;
	shellExitDir        = "0.5 -1.3 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;   
	shellVelocity       = 7.0;

	doColorShift = true;
	colorShiftColor = hl2ShotgunItem.colorShiftColor;

	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.01;
	stateTransitionOnTimeout[0]      = "Charge";
	stateSequence[0]                 = "Root";

	stateName[1]                = "Charge";
	stateTimeoutValue[1]        = 0.01;
	stateTransitionOnTimeout[1]       = "Fire";
	stateAllowImageChange[1]       = false;

	stateName[2]                     = "Fire";
	stateTransitionOnTimeOut[2]      = "Wait";
	stateSound[2]                    = hl2ShotgunAltFireSound;
	stateTimeoutValue[2]             = 0.2;
	stateFire[2]                     = true;
	stateAllowImageChange[2]         = false;
	stateSequence[2]                 = "dFire";
	stateScript[2]                   = "onFire";
	stateWaitForTimeout[2]           = true;
	stateEmitter[2]                  = hl2ShotgunFlashEmitter;
	stateEmitterTime[2]              = 0.05;
	stateEmitterNode[2]              = "muzzleNode";
	stateEjectShell[2]               = false;

	stateName[3]                = "Wait";
	stateTransitionOnTimeout[3]       = "Shell";
	stateAllowImageChange[3]       = false;
	stateTimeoutValue[3]        = 0.2;

	stateName[4]                    = "Cocking";
	stateTimeoutValue[4]            = 0.3;
	stateSequence[4]                = "cock";
	stateTransitionOnTimeout[4]     = "Delay";
	stateWaitForTimeout[4]          = true;
	stateEjectShell[4]              = true;
	stateSound[4]                   = hl2ShotgunReloadSound;

	stateName[5]                = "Delay";
	stateTimeoutValue[5]        = 0.15;
	stateTransitionOnTimeout[5] = "Done";

	stateName[6]                = "Done";
	stateAllowImageChange[6]       = true;
	stateSequence[6]            = "Ready";
	stateScript[6]              = "onDone";

	stateName[7]               = "Shell";
	stateTransitionOnTimeout[7] = "Cocking";
	stateEjectShell[7]         = true;
};

function hl2ShotgunAltFireImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,0);
}
function hl2ShotgunAltFireImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,-1);
}

function hl2ShotgunAltFireImage::onFire(%this, %obj, %slot)
{
	parent::onFire(%this, %obj, %slot);
	%obj.playThread(2, plant);
	%obj.schedule(100, playThread, 2, jump);
	hl2DisplayAmmo(%this, %obj, %slot);
}

function hl2ShotgunAltFireImage::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit )
{
	hl2ShotgunImage::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit );
}

function hl2ShotgunAltFireImage::onDone(%this, %obj, %slot)
{
	%obj.mountImage(hl2ShotgunImage, 0);
}

