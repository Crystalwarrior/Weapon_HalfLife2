//	+-----------------------------------+
//	|		HL2 Weapons Pack			|
//	|		by Zapk & Aware14			|
//	+-----------------------------------+
//	|		hl2Grenade.cs					|
//	+-----------------------------------+

//audio
datablock AudioProfile(hl2GrenadeBeepSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Grenade/GrenadeBeep.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2GrenadeBeepTickSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Grenade/tick1.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock ParticleData(hl2GrenadeBlinkParticle)
{
	dragCoefficient      = 0;
	gravityCoefficient   = 0;
	inheritedVelFactor   = 0;
	constantAcceleration = 0;
	lifetimeMS           = 200;
	lifetimeVarianceMS   = 0;
	textureName          = "base/data/particles/dot";
	spinSpeed      = 10.0;
	spinRandomMin     = -50.0;
	spinRandomMax     = 50.0;
	colors[0]     = "0.9 0 0 0.2";
	colors[1]     = "0.9 0 0 0";
	sizes[0]      = 1.0;
	sizes[1]      = 1.0;

	useInvAlpha = true;
};

datablock ParticleEmitterData(hl2GrenadeBlinkEmitter)
{
	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0;
	ejectionOffset   = 0;
	thetaMin         = 89;
	thetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2GrenadeBlinkParticle";

	//uiName = "Rocket Explosion Smoke";
	emitterNode = TenthEmitterNode;
};

datablock ExplosionData(hl2GrenadeBlinkExplosion)
{
	explosionShape = "";
	soundProfile = "";
	lifeTimeMS = 350;

	particleEmitter = hl2GrenadeBlinkEmitter;
	particleDensity = 1;
	particleRadius = 0.2;

	emitter[0] = "";//hl2GrenadeBlinkRingEmitter;

	faceViewer     = true;
	explosionScale = "1 1 1";

	shakeCamera = false;

	// Dynamic light
	lightStartRadius = 5;
	lightEndRadius = 1;
	lightStartColor = "1 0 0 0.5";
	lightEndColor = "1 0 0 0";

	damageRadius = 0;
	radiusDamage = 0;

	impulseRadius = 0;
	impulseForce = 0;
};

datablock projectileData(hl2GrenadeBlink)
{
	directDamage        = 0;
	explosion           = hl2GrenadeBlinkExplosion;
	explodeOnDeath = true;
	projectileType = Projectile;

	lifetime            = 0;
	hasLight    = false;
	lightRadius = 6.0;
	lightColor  = "1 0 0";
};

datablock ParticleData(hl2GrenadeExplosionParticle)
{
	dragCoefficient		= 1.0;
	windCoefficient		= 0.0;
	gravityCoefficient	= -0.2;
	inhl2GrenaderitedVelFactor	= 0.0;
	constantAcceleration	= 0.0;
	lifetimeMS		= 4000;
	lifetimeVarianceMS	= 3990;
	spinSpeed		= 10.0;
	spinRandomMin		= -50.0;
	spinRandomMax		= 50.0;
	useInvAlpha		= true;
	animateTexture		= false;
	//framesPerSec		= 1;

	textureName		= "base/data/particles/cloud";
	//animTexName		= "~/data/particles/cloud";

	// Interpolation variables
	colors[0]	= "0.2 0.2 0.2 1.0";
	colors[1]	= "0.25 0.25 0.25 0.2";
	colors[2]	= "0.4 0.4 0.4 0.0";

	sizes[0]	= 2.0;
	sizes[1]	= 10.0;
	sizes[2]	= 13.0;

	times[0]	= 0.0;
	times[1]	= 0.1;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(hl2GrenadeExplosionEmitter)
{
	ejectionPeriodMS = 7;
	periodVarianceMS = 0;
	lifeTimeMS	   = 21;
	ejectionVelocity = 10;
	velocityVariance = 1.0;
	ejectionOffset   = 1.0;
	thl2GrenadetaMin         = 0;
	thl2GrenadetaMax         = 0;
	phiReferenceVel  = 0;
	phiVariance      = 90;
	overrideAdvance = false;
	particles = "hl2GrenadeExplosionParticle";
};

datablock ParticleData(hl2GrenadeExplosionParticle2)
{
	dragCoefficient		= 1.0;
	windCoefficient		= 0.0;
	gravityCoefficient	= -0.0;
	inhl2GrenaderitedVelFactor	= 0.0;
	constantAcceleration	= 0.0;
	lifetimeMS		= 4000;
	lifetimeVarianceMS	= 3990;
	spinSpeed		= 10.0;
	spinRandomMin		= -50.0;
	spinRandomMax		= 50.0;
	useInvAlpha		= true;
	animateTexture		= false;
	//framesPerSec		= 1;

	textureName		= "base/data/particles/cloud";
	//animTexName		= "~/data/particles/cloud";

	// Interpolation variables
	colors[0]	= "0.2 0.2 0.2 0.0";
	colors[1]	= "0.25 0.25 0.25 0.2";
	colors[2]	= "0.4 0.4 0.4 0.0";

	sizes[0]	= 2.0;
	sizes[1]	= 10.0;
	sizes[2]	= 3.0;

	times[0]	= 0.0;
	times[1]	= 0.1;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(hl2GrenadeExplosionEmitter2)
{
	ejectionPeriodMS = 20;
	periodVarianceMS = 0;
	lifetimeMS       = 120;
	ejectionVelocity = 15;
	velocityVariance = 5.0;
	ejectionOffset   = 0.0;
	thl2GrenadetaMin         = 85;
	thl2GrenadetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2GrenadeExplosionParticle2";
};



datablock ParticleData(hl2GrenadeExplosionParticle3)
{
	dragCoefficient		= 1.0;
	windCoefficient		= 0.0;
	gravityCoefficient	= -0.2;
	inhl2GrenaderitedVelFactor	= 0.0;
	constantAcceleration	= 0.0;
	lifetimeMS		= 4000;
	lifetimeVarianceMS	= 3990;
	spinSpeed		= 10.0;
	spinRandomMin		= -50.0;
	spinRandomMax		= 50.0;
	useInvAlpha		= true;
	animateTexture		= false;
	//framesPerSec		= 1;

	textureName		= "base/data/particles/cloud";
	//animTexName		= "~/data/particles/cloud";

	// Interpolation variables
	colors[0]	= "0.2 0.2 0.2 0.0";
	colors[1]	= "0.25 0.25 0.25 0.2";
	colors[2]	= "0.4 0.4 0.4 0.0";

	sizes[0]	= 2.0;
	sizes[1]	= 10.0;
	sizes[2]	= 13.0;

	times[0]	= 0.0;
	times[1]	= 0.1;
	times[2]	= 1.0;
};

datablock ParticleEmitterData(hl2GrenadeExplosionEmitter3)
{
	ejectionPeriodMS = 10;
	periodVarianceMS = 0;
	lifetimeMS       = 150;
	ejectionVelocity = 20;
	velocityVariance = 5.0;
	ejectionOffset   = 0.0;
	thl2GrenadetaMin         = 85;
	thl2GrenadetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2GrenadeExplosionParticle3";
};

datablock ParticleData(hl2GrenadeExplosionParticle4)
{
	dragCoefficient		= 0.1;
	windCoefficient		= 0.0;
	gravityCoefficient	= 4.0;
	inhl2GrenaderitedVelFactor	= 0.0;
	constantAcceleration	= 0.0;
	lifetimeMS		= 1000;
	lifetimeVarianceMS	= 500;
	spinSpeed		= 10.0;
	spinRandomMin		= -50.0;
	spinRandomMax		= 50.0;
	useInvAlpha		= true;
	animateTexture		= false;
	//framesPerSec		= 1;

	textureName		= "base/data/particles/chunk";
	//animTexName		= "~/data/particles/cloud";

	// Interpolation variables
	colors[0]	= "0.1 0.1 0.1 1.0";
	colors[1]	= "0.2 0.2 0.2 0.0";
	sizes[0]	= 0.5;
	sizes[1]	= 0.13;
	times[0]	= 0.0;
	times[1]	= 1.0;
};

datablock ParticleEmitterData(hl2GrenadeExplosionEmitter4)
{
	ejectionPeriodMS = 1;
	timeMultiple     = 10;
	periodVarianceMS = 0;
	lifetimeMS       = 15;
	ejectionVelocity = 35;
	velocityVariance = 5.0;
	ejectionOffset   = 0.0;
	thl2GrenadetaMin         = 0;
	thl2GrenadetaMax         = 90;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2GrenadeExplosionParticle4";
};

datablock ExplosionData(hl2GrenadeExplosion)
{
	explosionShape = "Add-Ons/Weapon_Rocket_Launcher/explosionsphere1.dts";
	lifeTimeMS = 150;

	soundProfile = hl2GrenadeExplosionSound;
	
	emitter[0] = hl2GrenadeExplosionEmitter3;
	emitter[1] = hl2GrenadeExplosionEmitter2;
	emitter[2] = hl2GrenadeExplosionEmitter4;
	//emitter[1] = "";
	//emitter[2] = "";
	//emitter[0] = "";

	particleEmitter = hl2GrenadeExplosionEmitter;
	particleDensity = 10;
//   particleDensity = 0;
	particleRadius = 1.0;

	faceViewer     = true;
	explosionScale = "1 1 1";

	shakeCamera = true;
	camShakeFreq = "7.0 8.0 7.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 15.0;

	// Dynamic light
	lightStartRadius = 0;
	lightEndRadius = 0;
	lightStartColor = "0.45 0.3 0.1";
	lightEndColor = "0 0 0";

	//impulse
	impulseRadius = 20;
	impulseForce = 4000;

	//radius damage
	damageRadius = 17;
	radiusDamage = 250;

};

//projectile
AddDamageType("hl2GrenadeDirect",   '<bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Grenade> %1',    '%2 <bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Grenade> %1',1,1);
AddDamageType("hl2GrenadeRadius",   '<bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Grenade> %1',    '%2 <bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Grenade> %1',1,0);
datablock ProjectileData(hl2GrenadeProjectile)
{
	projectileShapeName = $hl2Weapons::Path @ "/Models/hl2_grenadethrown.dts";
	directDamage        = 0;
	directDamageType  = $DamageType::hl2GrenadeDirect;
	radiusDamageType  = $DamageType::hl2GrenadeRadius;
	impactImpulse	   = 200;
	verticalImpulse	   = 200;
	explosion           = hl2GrenadeExplosion;
	particleEmitter     = "";
	sound				= "";

	brickExplosionRadius = 10;
	brickExplosionImpact = false; //destroy a brick if we hit it directly?
	brickExplosionForce  = 25;             
	brickExplosionMaxVolume = 100;          //max volume of bricks that we can destroy
	brickExplosionMaxVolumeFloating = 60;  //max volume of bricks that we can destroy if thl2Grenadey aren't connected to thl2Grenade ground (should always be >= brickExplosionMaxVolume)

	muzzleVelocity      = 30;
	velInheritFactor    = 0;
	explodeOnDeath = true;

	armingDelay         = 3000; 
	lifetime            = 3000;
	fadeDelay           = 3000;
	bounceElasticity    = 0.4;
	bounceFriction      = 0.3;
	isBallistic         = true;
	gravityMod = 1;

	hasLight    = true;
	lightRadius = 1.0;
	lightColor  = "1 0 0";

	uiName = "Grenade Projectile";
};

datablock projectileData(hl2GrenadeRollProjectile : hl2GrenadeProjectile)
{
	projectileShapeName  = $hl2Weapons::Path @ "/Models/hl2_grenaderoll.dts";

	bounceElasticity    = 0.6;
	muzzleVelocity      = 15;
	bounceFriction      = 0;
	velInheritFactor    = 0.25;
	uiName = "";
};

//////////
// item //
//////////
datablock ItemData(hl2GrenadeItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = $hl2Weapons::Path @ "/Models/hl2_grenade.dts";
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "Combine Grenade";
	iconName = $hl2Weapons::Path @ "/Icons/Icon_Grenade";
	doColorShift = false;
	colorShiftColor = "0.400 0.196 0 1.000";

	 // Dynamic properties defined by thl2Grenade scripts
	image = hl2GrenadeImage;
	canDrop = true;
};

datablock ShapeBaseImageData(hl2GrenadeImage)
{
	// Basic Item properties
	shapeFile = $hl2Weapons::Path @ "/Models/hl2_grenade.dts";
	emap = true;

	// Specify mount point & offset for 3rd person, and eye offset
	// for first person rendering.
	mountPoint = 0;
	offset = "0 0 0";
	//eyeOffset = "0.1 0.2 -0.55";

	// Whl2Grenaden firing from a point offset from thl2Grenade eye, muzzle correction
	// will adjust thl2Grenade muzzle vector to point to thl2Grenade eye LOS point.
	// Since this weapon doesn't actually fire from thl2Grenade muzzle point,
	// we need to turn this off.  
	correctMuzzleVector = true;

	// Add thl2Grenade WeaponImage namespace as a parent, WeaponImage namespace
	// provides some hooks into thl2Grenade inventory system.
	className = "WeaponImage";

	// Projectile && Ammo.
	item = hl2GrenadeItem;
	ammo = " ";
	projectile = hl2GrenadeProjectile;
	projectileType = Projectile;

	//melee particles shoot from eye node for consistancy
	melee = false;
	//raise your arm up or not
	armReady = true;

	//casing = " ";
	doColorShift = false;
	colorShiftColor = "0.400 0.196 0 1.000";

	// Images have a state system which controls how thl2Grenade animations
	// are run, which sounds are played, script callbacks, etc. This
	// state system is downloaded to thl2Grenade client so that clients can
	// predict state changes and animate accordingly.  Thl2Grenade following
	// system supports basic ready->fire->reload transitions as
	// well as a no-ammo->dryfire idle state.

	// Initial start up state
	stateName[0]			= "Activate";
	stateTimeoutValue[0]		= 0.1;
	stateTransitionOnTimeout[0]	= "Ready";
	stateSequence[0]		= "ready";
	stateSound[0]					= "";

	stateName[1]			= "Ready";
	stateTransitionOnTriggerDown[1]	= "Charge";
	stateAllowImageChange[1]	= true;
	
	stateName[2]                    = "Charge";
	stateTransitionOnTimeout[2]	= "Armed";
	stateTimeoutValue[2]            = 0.7;
	stateWaitForTimeout[2]		= false;
	stateTransitionOnTriggerUp[2]	= "AbortCharge";
	stateScript[2]                  = "onCharge";
	stateAllowImageChange[2]        = false;
	
	stateName[3]			= "AbortCharge";
	stateTransitionOnTimeout[3]	= "Ready";
	stateTimeoutValue[3]		= 0.3;
	stateWaitForTimeout[3]		= true;
	stateScript[3]			= "onAbortCharge";
	stateAllowImageChange[3]	= false;

	stateName[4]			= "Armed";
	stateTransitionOnTriggerUp[4]	= "Fire";
	stateAllowImageChange[4]	= false;

	stateName[5]			= "Fire";
	//stateTransitionOnTimeout[5]	= "Ready";
	stateTimeoutValue[5]		= 0.5;
	stateFire[5]			= true;
	stateSequence[5]		= "fire";
	stateScript[5]			= "onFire";
	stateWaitForTimeout[5]		= true;
	stateAllowImageChange[5]	= false;
};

function Armor::hl2AltFireGrenade(%this, %obj, %slot, %val)
{
	%projectile = hl2GrenadeRollProjectile;
	%vector = %obj.getMuzzleVector(0);
	%objectVelocity = %obj.getVelocity();
	%vector1 = VectorScale(%vector, %projectile.muzzleVelocity);
	%vector2 = VectorScale(%objectVelocity, %projectile.velInheritFactor);
	%velocity = VectorAdd(%vector1,%vector2);
	%p = new Projectile()
	{
		dataBlock = %projectile;
		initialVelocity = %velocity;
		initialPosition = %obj.getMuzzlePoint(0);
		sourceObject = %obj;
		sourceSlot = 0;
		client = %obj.client;
	};
	%obj.lastGrenade = getSimTime();
	MissionCleanup.add(%p);
	%currSlot = %obj.lasthl2GrenadeSlot;
	%obj.tool[%currSlot] = 0;
	%obj.weaponCount--;
	messageClient(%obj.client,'MsgItemPickup','',%currSlot,0);
	serverCmdUnUseTool(%obj.client);
	%obj.playThread(2, "activate");
}

package hl2GrenadePackage
{
	function Armor::onTrigger(%this, %obj, %slot, %val)
	{
		if(%obj.getMountedImage(0) == nameToID(hl2GrenadeImage) && %slot $= 4 && %val)
		{
			if(%obj.getImageState(0) $= "Ready")
			{
				%obj.playThread(1, "root");
				%this.schedule(60, hl2AltFireGrenade, %obj, %slot, %val);
			}
		}
		Parent::onTrigger(%this, %obj, %slot, %val);
	}
};
activatePackage(hl2GrenadePackage);

function hl2GrenadeImage::onCharge(%this, %obj, %slot)
{
	%obj.playthread(2, "spearReady");
	%obj.lasthl2GrenadeSlot = %obj.currTool;
}

function hl2GrenadeImage::onAbortCharge(%this, %obj, %slot)
{
	%obj.playthread(2, "root");
}

function hl2GrenadeImage::onFire(%this, %obj, %slot)
{
	%obj.playthread(2, "spearThrow");
	Parent::OnFire(%this, %obj, %slot);

	%currSlot = %obj.lasthl2GrenadeSlot;
	%obj.tool[%currSlot] = 0;
	%obj.weaponCount--;
	messageClient(%obj.client,'MsgItemPickup','',%currSlot,0);
	serverCmdUnUseTool(%obj.client);
}

function Projectile::onAdd(%this,%a,%b)
{
	if(%this.dataBlock $= hl2GrenadeProjectile || %this.dataBlock $= hl2GrenadeRollProjectile)
	{
		beepTick(%this);
	}
}

function beepTick(%this)
{
	cancel(%this.beepTickLoop);
	if(!isObject(%this))
	{
		return;
	}

	%this.tick += 1;
	if( %this.tick > 5 )
	{
		return;
	}

	if( %this.tick > 2 )
	{
		%delay = 316;
	}
	else
	{
		%delay = 1000;
	}
	serverPlay3d(hl2GrenadeBeepTickSound, %this.getPosition());

	%projectile = new projectile()
	{
		dataBlock = hl2GrenadeBlink;
		initialPosition = %this.getPosition();
		sourceObject = %this;
	};
	MissionCleanup.add(%projectile);
	%this.beepTickLoop = schedule( %delay, 0, "beepTick", %this );
}

function hl2GrenadeImage::onDone(%this,%obj,%slot)
{
	%obj.unMountImage(%slot);
}