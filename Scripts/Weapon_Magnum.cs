//	+-----------------------------------+
//	|		HL2 Weapons Pack			|
//	|		by Zapk & Aware14			|
//	+-----------------------------------+
//	|		hl2Magnum.cs					|
//	+-----------------------------------+

//audio
datablock AudioProfile(hl2MagnumFireSound)
{
	filename    = $hl2Weapons::Path @ "/sounds/357/357_fire.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2MagnumReloadSound1)
{
	filename    = $hl2Weapons::Path @ "/sounds/357/357_reload1.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2MagnumReloadSound2)
{
	filename    = $hl2Weapons::Path @ "/sounds/357/357_reload2.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2MagnumReloadSound3)
{
	filename    = $hl2Weapons::Path @ "/sounds/357/357_reload3.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2MagnumSpinSound)
{
	filename    = $hl2Weapons::Path @ "/sounds/357/357_spin.wav";
	description = AudioClose3d;
	preload = true;
};

//shell
datablock DebrisData(hl2MagnumShellDebris)
{
	shapeFile = $hl2Weapons::Path @ "/Models/shell_357.dts";
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

datablock ParticleData(hl2MagnumSmokeParticle)
{
	dragCoefficient      = 3;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 525;
	lifetimeVarianceMS   = 55;
	textureName          = "base/data/particles/cloud";
	spinSpeed      = 10.0;
	spinRandomMin     = -500.0;
	spinRandomMax     = 500.0;
	colors[0]     = "0.5 0.5 0.5 0.9";
	colors[1]     = "0.5 0.5 0.5 0.0";
	sizes[0]      = 0.15;
	sizes[1]      = 0.15;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2MagnumSmokeEmitter)
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
	particles = "hl2MagnumSmokeParticle";

	//uiName = "hl2Magnum Smoke";
};

AddDamageType("hl2Magnum",   '<bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Magnum> %1',    '%2 <bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Magnum> %1',0.5,1);
datablock ProjectileData(hl2MagnumProjectile)
{
	projectileShapeName = "add-ons/weapon_gun/bullet.dts";
	directDamage        = 0;//75;
	directDamageType    = $DamageType::hl2Magnum;
	radiusDamageType    = $DamageType::hl2Magnum;

	brickExplosionRadius = 0;
	brickExplosionImpact = true;          //destroy a brick if we hit it directly?
	brickExplosionForce  = 10;
	brickExplosionMaxVolume = 1;          //max volume of bricks that we can destroy
	brickExplosionMaxVolumeFloating = 2;  //max volume of bricks that we can destroy if they aren't connected to the ground

	impactImpulse	     = 400;
	verticalImpulse	  = 400;
	explosion           = hl2PistolExplosion;
	particleEmitter     = ""; //bulletTrailEmitter;

	muzzleVelocity      = 90;
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

datablock ProjectileData(hl2MagnumTracerProjectile)
{
	projectileShapeName = $hl2Weapons::Path @ "/Models/bullet_9mm.dts";
	directDamage        = 0;//75;
	muzzleVelocity      = 200;
	velInheritFactor    = 1;
	lifetime            = 200;
	fadeDelay           = 100;
};
//////////
// item //
//////////
datablock ItemData(hl2MagnumItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = $hl2Weapons::Path @ "/models/hl2_revolver.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = ".357 Magnum";
	iconName = $hl2Weapons::Path @ "/icons/Icon_Magnum";
	doColorShift = true;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	maxmag = 6;
	ammotype = "357";
	reload = true;

	 // Dynamic properties defined by the scripts
	image = hl2MagnumImage;
	canDrop = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(hl2MagnumImage)
{
	// Basic Item properties
	shapeFile = $hl2Weapons::Path @ "/models/hl2_revolver.dts";
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
	item = hl2MagnumItem;
	ammo = " ";
	projectile = hl2MagnumProjectile;
	projectileType = Projectile;

	raycastWeaponRange = 400;
	raycastWeaponTargets =
						 $TypeMasks::PlayerObjectType |    //AI/Players
						 $TypeMasks::StaticObjectType |    //Static Shapes
						 $TypeMasks::TerrainObjectType |    //Terrain
						 $TypeMasks::VehicleObjectType |    //Terrain
						 $TypeMasks::FXBrickObjectType;    //Bricks
	raycastExplosionProjectile = hl2MagnumProjectile;
	raycastExplosionBrickSound = "";
	raycastExplosionPlayerSound = "";
	raycastDirectDamage = 75;
	raycastDirectDamageType = $DamageType::hl2Magnum;
	raycastSpreadAmt = 0.0001;
	raycastSpreadCount = 1;
	raycastTracerProjectile = hl2MagnumTracerProjectile;
	raycastTracerShape = hl2TracerShapeData;
	raycastTracerSize = 1.5;
	raycastTracerColor = "0.8 0.5 0.0 1";
	raycastFromMuzzle = true;

	casing = hl2MagnumShellDebris;
	shellExitDir        = "0 -0.1 0";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;   
	shellVelocity       = 7.0;

	//melee particles shoot from eye node for consistancy
	melee = false;
	//raise your arm up or not
	armReady = true;

	doColorShift = true;
	colorShiftColor = hl2MagnumItem.colorShiftColor;//"0.400 0.196 0 1.000";

	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.15;
	stateTransitionOnTimeout[0]      = "AmmoCheck";
	stateSound[0]                    = "";//hl2weaponSwitchSound;

	stateName[1]                     = "Ready";
	stateTransitionOnTriggerDown[1]  = "Fire";
	stateTransitionOnNoAmmo[1]       = "Empty";
	stateAllowImageChange[1]         = true;
	stateSequence[1]                 = "root";

	stateName[2]                     = "Fire";
	stateTransitionOnTriggerUp[2]    = "Delay";
	stateTimeoutValue[2]             = 0.3;
	stateFire[2]                     = true;
	stateAllowImageChange[2]         = false;
	stateSequence[2]                 = "Fire";
	stateScript[2]                   = "onFire";
	stateWaitForTimeout[2]           = true;
	stateEmitter[2]                  = hl2PistolFlashEmitter;
	stateSound[2]                    = hl2MagnumFireSound;
	stateEmitterTime[2]              = 0.05;
	stateEmitterNode[2]              = "muzzleNode";
	stateEjectShell[2]               = false;

	stateName[3]                     = "AmmoCheck";
	stateTransitionOnTimeout[3]      = "Ready";
	stateAllowImageChange[3]         = true;
	stateScript[3]                   = "onAmmoCheck";

	stateName[4]                     = "Reload";
	stateTransitionOnTimeout[4]      = "ejectShell1";
	stateTimeoutValue[4]             = 0.8;
	stateAllowImageChange[4]         = true;
	stateSequence[4]                 = "reloadStart";
	stateScript[4]                   = "onReloadStart";

	stateName[5]                     = "ReloadMid";
	stateTransitionOnTimeout[5]      = "ReloadReady";
	stateTimeoutValue[5]             = 1;
	stateAllowImageChange[5]         = true;
	stateSequence[5]                 = "reloadEnd";
	stateScript[5]                   = "onReloadMid";

	stateName[6]                     = "ReloadReady";
	stateTransitionOnTimeout[6]      = "CheckChamber";
	stateTimeoutValue[6]             = 0.5;
	stateAllowImageChange[6]         = true;
	stateSequence[6]                 = "rollChamber";
	stateScript[6]                   = "onReload";

	stateName[7]                     = "Empty";
	stateTransitionOnTriggerDown[7]  = "EmptyFire";
	stateAllowImageChange[7]         = true;
	stateScript[7]                   = "onEmpty";
	stateTransitionOnAmmo[7]         = "Reload";
	stateSequence[7]                 = "noammo";

	stateName[8]                     = "EmptyFire";
	stateTransitionOnTriggerUp[8]    = "Empty";
	stateTimeoutValue[8]             = 0.13;
	stateAllowImageChange[8]         = false;
	stateWaitForTimeout[8]           = true;
	stateSound[8]                    = hl2PistolEmptySound;
	stateSequence[8]                 = "noammo_fire";

	stateName[9]                     = "CheckChamber";
	stateTransitionOnTimeOut[9]      = "Ready";
	stateTransitionOnNoAmmo[9]       = "Cocking";
	stateAllowImageChange[9]         = true;
 
	stateName[10]                     = "Cocking";
	stateTransitionOnTimeOut[10]      = "Ready";
	stateTimeoutValue[10]             = 0.1;
	stateAllowImageChange[10]         = true;
	stateWaitForTimeout[10]           = true;
	stateSound[10]                    = "";
	stateScript[10]                   = "onCock";

	stateName[11]                    = "Delay";
	stateTimeoutValue[11]            = 0.35;
	stateTransitionOnTimeout[11]     = "AmmoCheck";
	stateEmitter[11]                 = "gunSmoke";

	stateName[12]                    = "ejectShell1";
	stateTransitionOnTimeout[12]     = "ejectShell2";
	stateEjectShell[12]              = true;

	stateName[13]                    = "ejectShell2";
	stateTransitionOnTimeout[13]     = "ejectShell3";
	stateEjectShell[13]              = true;

	stateName[14]                    = "ejectShell3";
	stateTransitionOnTimeout[14]     = "ejectShell4";
	stateEjectShell[14]              = true;

	stateName[15]                    = "ejectShell4";
	stateTransitionOnTimeout[15]     = "ejectShell5";
	stateEjectShell[15]              = true;

	stateName[16]                    = "ejectShell5";
	stateTransitionOnTimeout[16]     = "ejectShell6";
	stateEjectShell[16]              = true;

	stateName[17]                    = "ejectShell6";
	stateTransitionOnTimeout[17]     = "ReloadMid";
	stateEjectShell[17]              = true;
};

function hl2MagnumImage::onReloadStart( %this, %obj, %slot )
{
	%pos = %obj.getHackPosition();
	%obj.playThread(2,shiftLeft);

	%rnd = getRandom(1,3);
	%sound = hl2MagnumReloadSound @ %rnd;
	serverPlay3d(%sound, %pos);

	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2MagnumImage::onReloadMid( %this, %obj, %slot )
{
	%pos = %obj.getHackPosition();

	%rnd = getRandom(1,3);
	%sound = hl2MagnumReloadSound @ %rnd;
	serverPlay3d(%sound, %pos);
	%obj.playThread(2, plant);
	//hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2MagnumImage::onAmmoCheck( %this, %obj, %slot )
{
	hl2AmmoCheck(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2MagnumImage::onReload( %this, %obj, %slot )
{
  // %obj.playThread(2,rotCCW);
	serverPlay3d(hl2MagnumSpinSound, %obj.getHackPosition());
	hl2AmmoOnReload(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2MagnumImage::onCock( %this, %obj, %slot )
{
	%obj.setImageAmmo(0,1);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2MagnumImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,0);
}
function hl2MagnumImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,-1);
}

function hl2MagnumImage::onFire(%this,%obj,%slot)
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

	Parent::onFire(%this,%obj,%slot);
	%obj.playThread(2, shiftAway);	
}

function hl2MagnumImage::onEmpty(%this,%obj,%slot)
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

function hl2MagnumImage::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit )
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

function hl2MagnumImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
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
