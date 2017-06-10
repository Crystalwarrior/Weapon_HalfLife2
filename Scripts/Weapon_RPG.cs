//hl2RPG.cs

//audio
datablock AudioProfile(hl2RocketFireSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/RPG/rocketFire.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2RocketExplodeSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/RPG/explode.wav";
	description = AudioDefault3d;
	preload = true;
};
datablock AudioProfile(hl2RocketLoopSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/RPG/rocketLoop.wav";
	description = AudioCloseLooping3d;
	preload = true;
};
datablock AudioProfile(hl2RocketStartSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/RPG/rocketStart.wav";
	description = AudioClose3d;
	preload = true;
};


//muzzle flash effects
datablock ParticleData(hl2RPGFlashParticle)
{
	dragCoefficient      = 1;
	gravityCoefficient   = 1.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 1500;
	lifetimeVarianceMS   = 150;
	textureName          = "base/data/particles/star1";
	spinSpeed      = 10.0;
	spinRandomMin     = -500.0;
	spinRandomMax     = 500.0;
	colors[0]     = "0.9 0.4 0.0 0.9";
	colors[1]     = "0.9 0.5 0.0 0.0";
	sizes[0]      = 0.25;
	sizes[1]      = 0.0;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2RPGFlashEmitter)
{
	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 10.0;
	velocityVariance = 1.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 180;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2RPGFlashParticle";

	//uiName = "Rocket Launcher Spark";
};

datablock ParticleData(hl2RPGSmokeParticle)
{
	dragCoefficient      = 5;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 300;
	lifetimeVarianceMS   = 250;
	textureName          = "base/data/particles/cloud";
	spinSpeed      = 10.0;
	spinRandomMin     = -500.0;
	spinRandomMax     = 500.0;

	colors[0]     = "0.5 0.5 0.5 0.0";
	colors[1]     = "0.5 0.5 0.5 0.9";
	colors[2]     = "0.5 0.5 0.5 0.0";

	sizes[0]      = 0.25;
	sizes[1]      = 1.0;
	sizes[2]      = 1.75;

	times[0] = 0.0;
	times[1] = 0.5;
	times[2] = 1.0;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2RPGSmokeEmitter)
{
	ejectionPeriodMS = 5;
	periodVarianceMS = 0;
	ejectionVelocity = 10.0;
	velocityVariance = 0.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 25;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2RPGSmokeParticle";

	//uiName = "Rocket Launcher Smoke";
};


//bullet trail effects
datablock ParticleData(hl2RocketTrailParticle)
{
	dragCoefficient      = 3;
	gravityCoefficient   = -0.0;
	inheritedVelFactor   = 0.15;
	constantAcceleration = 0.0;
	lifetimeMS           = 1000;
	lifetimeVarianceMS   = 805;
	textureName          = "base/data/particles/cloud";
	spinSpeed      = 10.0;
	spinRandomMin     = -150.0;
	spinRandomMax     = 150.0;
	colors[0]     = "1.0 1.0 0.0 0.4";
	colors[1]     = "1.0 0.2 0.0 0.5";
	colors[2]     = "0.20 0.20 0.20 0.3";
	colors[3]     = "0.0 0.0 0.0 0.0";

	sizes[0]      = 0.25;
	sizes[1]      = 0.85;
	sizes[2]      = 0.35;
	sizes[3]      = 0.05;

	times[0] = 0.0;
	times[1] = 0.05;
	times[2] = 0.3;
	times[3] = 1.0;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2RocketTrailEmitter)
{
	ejectionPeriodMS = 5;
	periodVarianceMS = 1;
	ejectionVelocity = 0.25;
	velocityVariance = 0.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2RocketTrailParticle";

	//uiName = "Rocket Trail";
};


datablock ParticleData(hl2RocketExplosionParticle)
{
	dragCoefficient      = 3;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 700;
	lifetimeVarianceMS   = 400;
	textureName          = "base/data/particles/cloud";
	spinSpeed      = 10.0;
	spinRandomMin     = -50.0;
	spinRandomMax     = 50.0;
	colors[0]     = "0.9 0.9 0.6 0.9";
	colors[1]     = "0.9 0.5 0.6 0.0";
	sizes[0]      = 10.0;
	sizes[1]      = 15.0;

	useInvAlpha = true;
};
datablock ParticleEmitterData(hl2RocketExplosionEmitter)
{
	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 10;
	velocityVariance = 1.0;
	ejectionOffset   = 3.0;
	thetaMin         = 89;
	thetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2RocketExplosionParticle";

	//uiName = "Rocket Explosion Smoke";
	emitterNode = TenthEmitterNode;
};


datablock ParticleData(hl2RocketExplosionRingParticle)
{
	dragCoefficient      = 8;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 40;
	lifetimeVarianceMS   = 10;
	textureName          = "base/data/particles/star1";
	spinSpeed      = 10.0;
	spinRandomMin     = -500.0;
	spinRandomMax     = 500.0;
	colors[0]     = "1 0.5 0.2 0.5";
	colors[1]     = "0.9 0.0 0.0 0.0";
	sizes[0]      = 8;
	sizes[1]      = 13;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2RocketExplosionRingEmitter)
{
	lifeTimeMS = 50;

	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 5;
	velocityVariance = 0.0;
	ejectionOffset   = 3.0;
	thetaMin         = 0;
	thetaMax         = 180;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2RocketExplosionRingParticle";

	//uiName = "Rocket Explosion Flash";
};

datablock ExplosionData(hl2RocketExplosion)
{
	//explosionShape = "";
	explosionShape = "Add-Ons/Weapon_Rocket_Launcher/explosionSphere1.dts";
	soundProfile = hl2RocketExplodeSound;

	lifeTimeMS = 350;

	particleEmitter = hl2RocketExplosionEmitter;
	particleDensity = 10;
	particleRadius = 0.2;

	emitter[0] = hl2RocketExplosionRingEmitter;

	faceViewer     = true;
	explosionScale = "1 1 1";

	shakeCamera = true;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "3.0 10.0 3.0";
	camShakeDuration = 0.5;
	camShakeRadius = 20.0;

	// Dynamic light
	lightStartRadius = 10;
	lightEndRadius = 25;
	lightStartColor = "1 1 1 1";
	lightEndColor = "0 0 0 1";

	damageRadius = 3;
	radiusDamage = 100;

	impulseRadius = 6;
	impulseForce = 4000;
};


AddDamageType("hl2RocketDirect",   '<bitmap:add-ons/Weapon_Rocket_Launcher/CI_rocket> %1',    '%2 <bitmap:add-ons/Weapon_Rocket_Launcher/CI_rocket> %1',1,1);
AddDamageType("hl2RocketRadius",   '<bitmap:add-ons/Weapon_Rocket_Launcher/CI_rocketRadius> %1',    '%2 <bitmap:add-ons/Weapon_Rocket_Launcher/CI_rocketRadius> %1',1,0);
datablock ProjectileData(hl2RPGProjectile)
{
	projectileShapeName = "Add-Ons/Weapon_Rocket_Launcher/RocketProjectile.dts";
	directDamage        = 30;
	directDamageType = $DamageType::hl2RocketDirect;
	radiusDamageType = $DamageType::hl2RocketRadius;
	impactImpulse     = 1000;
	verticalImpulse      = 1000;
	explosion           = hl2RocketExplosion;
	particleEmitter     = hl2RocketTrailEmitter;

	brickExplosionRadius = 3;
	brickExplosionImpact = false;          //destroy a brick if we hit it directly?
	brickExplosionForce  = 30;             
	brickExplosionMaxVolume = 30;          //max volume of bricks that we can destroy
	brickExplosionMaxVolumeFloating = 60;  //max volume of bricks that we can destroy if they aren't connected to the ground (should always be >= brickExplosionMaxVolume)

	sound = hl2RocketLoopSound;

	muzzleVelocity      = 65;
	velInheritFactor    = 1.0;

	armingDelay         = 00;
	lifetime            = 4000;
	fadeDelay           = 3500;
	bounceElasticity    = 0.5;
	bounceFriction      = 0.20;
	isBallistic         = false;
	gravityMod = 0.0;

	hasLight    = true;
	lightRadius = 5.0;
	lightColor  = "1 0.5 0.0";

	uiName = "RPG Rocket";
};

//////////
// item //
//////////
datablock ItemData(hl2RPGItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = "Add-Ons/Weapon_Rocket_Launcher/rocketlauncher.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "RPG";
	//iconName = "./icon_hl2RPG";
	doColorShift = true;
	colorShiftColor = "0.100 0.500 0.250 1.000";

	 // Dynamic properties defined by the scripts
	image = hl2RPGImage;
	canDrop = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(hl2RPGImage)
{
	// Basic Item properties
	shapeFile = hl2RPGItem.shapeFile;
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
	item = hl2RPGItem;
	ammo = " ";
	projectile = hl2RPGProjectile;
	projectileType = Projectile;

	//casing = hl2RPGShellDebris;
	shellExitDir        = "1.0 -1.3 1.0";
	shellExitOffset     = "0 0 0";
	shellVelocity       = 7.0;
	shellExitVariance   = 15.0;   

	melee = false;

	armReady = true;
	minShotTime = 0;

	doColorShift = true;
	colorShiftColor = hl2RPGItem.colorShiftColor;

	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.1;
	stateTransitionOnTimeout[0]       = "AmmoCheck";
	stateSound[0]              = weaponSwitchSound;

	stateName[1]                     = "Ready";
	stateTransitionOnTriggerDown[1]  = "Fire";
	stateAllowImageChange[1]         = true;
	stateTransitionOnNoAmmo[1]       = "NoAmmo";
	stateSequence[1]  = "Ready";

	stateName[2]                    = "Fire";
	stateTransitionOnTimeout[2]     = "Smoke";
	stateTimeoutValue[2]            = 0.1;
	stateFire[2]                    = true;
	stateAllowImageChange[2]        = false;
	stateSequence[2]                = "Fire";
	stateScript[2]                  = "onFire";
	stateWaitForTimeout[2]        = true;
	stateEmitter[2]               = hl2RPGFlashEmitter;
	stateEmitterTime[2]           = 0.05;
	stateEmitterNode[2]           = tailNode;
	stateSound[2]              = hl2RocketFireSound;
	stateSequence[2]                = "Fire";
	//stateEjectShell[2]       = true;

	stateName[3] = "Smoke";
	stateEmitter[3]               = hl2RPGSmokeEmitter;
	stateEmitterTime[3]           = 0.05;
	stateEmitterNode[3]           = "muzzleNode";
	stateTimeoutValue[3]            = 0.1;
	stateSequence[3]                = "TrigDown";
	stateTransitionOnTimeout[3]     = "CoolDown";

	stateName[4]         = "Reload";
	stateTransitionOnTimeUp[4]     = "Ready";
	stateTimeoutValue[4]             = 0.5;
	stateSequence[4]              = "onReload";

	stateName[5] = "CoolDown";
	stateTimeoutValue[5]            = 0.5;
	stateTransitionOnTimeout[5]     = "AmmoCheck";
	stateSequence[5]                = "TrigDown";

	stateName[6]   = "NoAmmo";
	stateScript[6] = "onNoAmmo";
	stateTransitionOnTrigger[6] = "ammoCheck";
	stateTransitionOnAmmo[6] = "Reload";

	stateName[7]               = "AmmoCheck";
	stateTransitionOnTimeout[7]      = "Ready";
	stateAllowImageChange[7]         = true;
	stateSequence[7]           = "onAmmoCheck";
};

function hl2RPGImage::onMount(%this, %obj, %slot) {
	if(isObject(%obj.rocketProjectile))
	{
		%obj.setImageAmmo(0, 0);
	}
	else
	{
		%obj.setImageAmmo(0, 1);
	}
}

function hl2RPGImage::onFire(%this, %obj, %slot) {
	//if (!isObject(%obj.rocketProjectile)) {
		parent::onFire(%this, %obj, %slot);
		%obj.setImageAmmo(0, 0);
		serverPlay3D(hl2RocketStartSound, %obj.getHackPosition());
	//}
}

function hl2RPGImage::onNoAmmo(%this, %obj, %slot) {
	if (!isObject(%obj.rocketProjectile)) {
		%obj.setImageAmmo(0, 1);
	}
}

function hl2RPGImage::onAmmoCheck(%this, %obj, %slot) {
	if (isObject(%obj.rocketProjectile)) {
		%obj.setImageAmmo(0, 0);
	}
	else {
		%obj.setImageAmmo(0, 1);
	}
}

function hl2RPGImage::onReload(%this, %obj, %slot) {
	%obj.setImageAmmo(0, 1);
}

package homingRockets {
	function Projectile::onAdd(%this) {
		parent::onAdd(%this);

		if (%this.getDataBlock() != nameToID("hl2RPGprojectile")) {
			return;
		}

		if (isObject(%this.sourceObject)) {
			if (%this.initialSpeed $= "") {
				%this.initialSpeed = vectorLen(%this.initialVelocity);
			}

			if (%this.spawnTime $= "") {
				%this.spawnTime = $Sim::Time;
			}

			%this.sourceObject.rocketProjectile = %this;
			%this.rocketHomingTick = %this.schedule(100, "rocketHomingTick", %this.sourceObject);
		}
	}

	function ProjectileData::onExplode(%this, %obj, %pos) {
		parent::onExplode(%this, %obj, %pos);
		if (%this != nameToID("hl2RPGprojectile") || %obj.lost) {
			return;
		}
		cancel(%obj.rocketHomingTick);
		if(isObject(%obj.sourceObject))
		{
			%obj.sourceObject.rocketProjectile = "";
			%obj.sourceObject.setImageAmmo(0, 1);
		}
	}
};

activatePackage("homingRockets");

function Projectile::rocketHomingTick(%this, %obj) {
	// echo(%this @ "::rocketHomingTick");

	if (!isObject(%obj) || %obj.getState() $= "Dead") {
		return;
	}

	if ($Sim::Time - %this.spawnTime >= %this.getDataBlock().lifeTime / 10) {
		%this.delete();
		return;
	}

	%point = %obj.getMuzzlePoint(0);
	%vector = %obj.getMuzzleVector(0);

	%target = vectorAdd(%point, vectorScale(%vector, 200));
	%ray = containerRayCast(%point, %target, $TypeMasks::All, %this);
	if(vectorDist(%this.getPosition(), %target) < 9)
	{
		%obj.rocketProjectile = "";
		%obj.setImageAmmo(0, 1);
		%this.lost = true;
		return;
	}

	if (%ray !$= 0) {
		%target = getWords(%ray, 1, 3);
	}
	else {
		//%this.rocketHomingTick = %this.schedule(100, "rocketHomingTick", %obj);
		//return;

	}

	%optimal = vectorNormalize(vectorSub(%target, %this.position));
	%current = vectorNormalize(%this.getVelocity());

	%difference = vectorSub(%optimal, %current);
	%amount = vectorLen(%difference);

	if (%amount <= 0.01) {
		%this.rocketHomingTick = %this.schedule(100, "rocketHomingTick", %obj);
		return;
	}

	%speed = 0.35;

	if (%amount < %speed) {
		%direction = %optimal;
	}
	else {
		%direction = vectorAdd(%current, vectorScale(%difference, %speed));
	}

	%velocity = vectorScale(%direction, %this.initialSpeed);
	%this.setName("temporaryProjectileCopy");

	%copy = new Projectile("" : temporaryProjectileCopy) {
		initialVelocity = %velocity;
	};

	MissionCleanup.add(%copy);
	%this.delete();
}