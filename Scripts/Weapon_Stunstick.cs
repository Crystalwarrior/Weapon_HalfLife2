//audio
datablock AudioProfile(hl2StunstickDrawSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Stunstick/Stunstick_Draw.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2StunstickHitSound1)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Stunstick/Stunstick_Impact1.wav";
	description = AudioClosest3d;
	preload = true;
};
datablock AudioProfile(hl2StunstickHitSound2)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Stunstick/Stunstick_Impact2.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2StunstickFleshHitSound1)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Stunstick/Stunstick_Fleshhit1.wav";
	description = AudioClosest3d;
	preload = true;
};
datablock AudioProfile(hl2StunstickFleshHitSound2)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Stunstick/Stunstick_Fleshhit2.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2StunstickSwingSound1)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Stunstick/Stunstick_Swing1.wav";
	description = AudioClosest3d;
	preload = true;
};
datablock AudioProfile(hl2StunstickSwingSound2)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Stunstick/Stunstick_Swing2.wav";
	description = AudioClosest3d;
	preload = true;
};


//effects
datablock ParticleData(hl2StunstickExplosionParticle)
{
	dragCoefficient      = 2;
	gravityCoefficient   = 1.0;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	spinRandomMin = -90;
	spinRandomMax = 90;
	lifetimeMS           = 500;
	lifetimeVarianceMS   = 300;
	textureName          = $hl2Weapons::Path @ "/Models/bolt";
	colors[0]     = "0.7 0.7 0.9 0.9";
	colors[1]     = "0.9 0.9 0.9 0.0";
	sizes[0]      = 0.5;
	sizes[1]      = 0.25;
};

datablock ParticleEmitterData(hl2StunstickExplosionEmitter)
{
	ejectionPeriodMS = 7;
	periodVarianceMS = 0;
	ejectionVelocity = 8;
	velocityVariance = 1.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 60;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2StunstickExplosionParticle";

	uiName = "";
};

datablock ExplosionData(hl2StunstickExplosion)
{
	//explosionShape = "";
	lifeTimeMS = 500;

	//soundProfile = hl2StunstickHitSound;

	particleEmitter = hl2StunstickExplosionEmitter;
	particleDensity = 10;
	particleRadius = 0.2;

	faceViewer     = true;
	explosionScale = "1 1 1";

	shakeCamera = true;
	camShakeFreq = "20.0 22.0 20.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10.0;

	// Dynamic light
	lightStartRadius = 3;
	lightEndRadius = 0;
	lightStartColor = "00.0 0.2 0.6";
	lightEndColor = "0 0 0";
};

//Muzzle Electricity stuff
datablock ParticleData(hl2StunstickMuzzleParticle)
{
	dragCoefficient      = 0;
	gravityCoefficient   = 0;
	inheritedVelFactor   = 0;
	constantAcceleration = 0.0;
	spinRandomMin = 0;
	spinRandomMax = 0;
	lifetimeMS           = 10;
	lifetimeVarianceMS   = 10;
	textureName          = "base/data/particles/cloud";
	colors[0]     = "0.7 0.7 0.9 0.9";
	colors[1]     = "0.9 0.9 0.9 0.0";
	sizes[0]      = 0.5;
	sizes[1]      = 0.25;
};

datablock ParticleEmitterData(hl2StunstickMuzzleEmitter)
{
	ejectionPeriodMS = 0;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 0;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2StunstickMuzzleParticle";

	uiName = "";
};


//projectile
AddDamageType("hl2Stunstick",    '<bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Stunstick> %1',    '%2 <bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Stunstick> %1',0.5,1);
datablock ProjectileData(hl2StunstickProjectile)
{
	directDamage        = 0;
	directDamageType  = $DamageType::hl2Stunstick;
	radiusDamageType  = $DamageType::hl2Stunstick;
	explosion           = hl2StunstickExplosion;
	//particleEmitter     = as;

	muzzleVelocity      = 50;
	velInheritFactor    = 1;

	armingDelay         = 0;
	lifetime            = 100;
	fadeDelay           = 70;
	bounceElasticity    = 0;
	bounceFriction      = 0;
	isBallistic         = false;
	gravityMod = 0.0;

	hasLight    = false;
	lightRadius = 3.0;
	lightColor  = "0 0 0.5";

	uiName = "";
};


//////////
// item //
//////////
datablock ItemData(hl2StunstickItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = $hl2Weapons::Path @ "/Models/Stunstick.dts";
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "Stunstick";
	iconName = $hl2Weapons::Path @ "/Icons/Icon_Stunstick";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";

	 // Dynamic properties defined by the scripts
	image = hl2StunstickImage;
	canDrop = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(hl2StunstickImage)
{
	// Basic Item properties
	shapeFile = $hl2Weapons::Path @ "/Models/Stunstick.dts";
	emap = true;

	// Specify mount point & offset for 3rd person, and eye offset
	// for first person rendering.
	mountPoint = 0;
	offset = "0 0 0";

	// When firing from a point offset from the eye, muzzle correction
	// will adjust the muzzle vector to point to the eye LOS point.
	// Since this weapon doesn't actually fire from the muzzle point,
	// we need to turn this off.  
	correctMuzzleVector = false;

	eyeOffset = "0 0 0";

	// Add the WeaponImage namespace as a parent, WeaponImage namespace
	// provides some hooks into the inventory system.
	className = "WeaponImage";

	// Projectile && Ammo.
	item = hl2StunstickItem;
	ammo = " ";
	projectile = hl2StunstickProjectile;
	projectileType = Projectile;

	raycastWeaponRange = 4;
	raycastWeaponTargets =
						 $TypeMasks::PlayerObjectType |    //AI/Players
						 $TypeMasks::StaticObjectType |    //Static Shapes
						 $TypeMasks::TerrainObjectType |    //Terrain
						 $TypeMasks::VehicleObjectType |    //Terrain
						 $TypeMasks::FXBrickObjectType;    //Bricks
	raycastExplosionProjectile = hl2StunstickProjectile;
	raycastExplosionBrickSound = "";
	raycastExplosionPlayerSound = "";
	raycastDirectDamage = 30;
	raycastDirectDamageType = $DamageType::hl2Stunstick;
	//raycastSpreadAmt = 0.0006;
	raycastSpreadCount = 1;
	raycastTracerProjectile = "";
	raycastFromMuzzle = false;

	//melee particles shoot from eye node for consistancy
	melee = true;
	doRetraction = false;
	//raise your arm up or not
	armReady = true;

	//casing = " ";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";

	// Images have a state system which controls how the animations
	// are run, which sounds are played, script callbacks, etc. This
	// state system is downloaded to the client so that clients can
	// predict state changes and animate accordingly.  The following
	// system supports basic ready->fire->reload transitions as
	// well as a no-ammo->dryfire idle state.

	// Initial start up state
	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.1;
	stateTransitionOnTimeout[0]      = "Ready";
	stateSound[0]                    = hl2StunstickDrawSound;

	stateName[1]                     = "Ready";
	stateEmitter[1]					 = hl2StunstickMuzzleemitter;
	stateTransitionOnTriggerDown[1]  = "AmmoCheck";
	stateAllowImageChange[1]         = true;

	stateName[2]                     = "AmmoCheck";
	stateTransitionOnTimeout[2]      = "PreFire";
	stateTransitionOnNoAmmo[2]       = "Fire";
	stateAllowImageChange[2]         = true;

	stateName[3]                     = "PreFire";
	stateScript[3]                   = "onPreFire";
	stateAllowImageChange[3]         = false;
	stateTimeoutValue[3]             = 0.2;
	stateTransitionOnTimeout[3]      = "Fire";

	stateName[4]                     = "Fire";
	stateTransitionOnTimeout[4]      = "CheckFire";
	stateEmitter[4]					 = hl2StunstickMuzzleemitter;
	stateEmitterNode[4]				 = "muzzleNode";
	stateTimeoutValue[4]             = 0.4;
	stateFire[4]                     = true;
	stateAllowImageChange[4]         = false;
	stateSequence[4]                 = "Fire";
	stateScript[4]                   = "onFire";
	stateWaitForTimeout[4]		       = true;

	stateName[5]                     = "CheckFire";
	stateTransitionOnTriggerUp[5]    = "StopFire";
	stateTransitionOnTriggerDown[5]  = "Ready";

	stateName[6]                     = "StopFire";
	stateTransitionOnTimeout[6]      = "Ready";
	stateTimeoutValue[6]             = 0.3;
	stateAllowImageChange[6]         = false;
	stateWaitForTimeout[6]		       = true;
	stateSequence[6]                 = "StopFire";
	stateScript[6]                   = "onStopFire";

};

function hl2StunstickImage::onPreFire(%this, %obj, %slot)
{
	%rnd = getRandom( 1, 2 );
	serverPlay3d( hl2StunstickSwingSound @ %rnd, %obj.getHackPosition() );
	%obj.playthread(2, shiftAway);
}

function hl2StunstickImage::onStopFire(%this, %obj, %slot)
{
	%obj.setImageAmmo(0, 1);
}

function hl2StunstickImage::onFire(%this, %obj, %slot)
{
	parent::onFire(%this, %obj, %slot);
	%obj.playthread(2, shiftTo);
	%obj.playthread(3, shiftleft); 
}
function hl2StunstickImage::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit )
{
	cancel(%obj.crowbarSchedule);
	%obj.setImageAmmo(0, 0);
	if( !( %col.getType() & $typeMasks::playerObjectType ) )
	{
		%rnd = getRandom( 1, 2 );
		serverPlay3d( hl2StunstickHitSound @ %rnd, %pos );
	}
	else
	{
		%rnd = getRandom( 1, 2 );
		serverPlay3d( hl2StunstickFleshHitSound @ %rnd, %pos );
		%col.setWhiteOut(1);
	}

	if( !(%col.getType() & $typeMasks::playerObjectType) && !(%col.getType & $TypeMasks::vehicleObjectType) )
	{
		spawnDecal(gunShotShapeData, vectorAdd(%pos, vectorScale(%normal, 0.02)), %normal);
	}

	%obj.crowbarSchedule = %obj.schedule(450, setImageAmmo, 0, 1);
	parent::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit );
}