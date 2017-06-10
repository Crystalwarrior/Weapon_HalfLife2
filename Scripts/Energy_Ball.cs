datablock AudioProfile(hl2energyBallDisintegrateSound1)
{
   filename    = $hl2Weapons::Path @ "/Sounds/EnergyBall/energy_disintegrate1.wav";
   description = AudioClosest3d;
   preload = true;
};
datablock AudioProfile(hl2energyBallDisintegrateSound2)
{
   filename    = $hl2Weapons::Path @ "/Sounds/EnergyBall/energy_disintegrate2.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(hl2energyBallExplosionSound)
{
   filename    = $hl2Weapons::Path @ "/Sounds/EnergyBall/energy_explosion.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(hl2energyBallBounceSound1)
{
   filename    = $hl2Weapons::Path @ "/Sounds/EnergyBall/energy_bounce1.wav";
   description = AudioClosest3d;
   preload = true;
};
datablock AudioProfile(hl2energyBallBounceSound2)
{
   filename    = $hl2Weapons::Path @ "/Sounds/EnergyBall/energy_bounce2.wav";
   description = AudioClosest3d;
   preload = true;
};


//The radio wave travel sound is really, really quiet
datablock AudioDescription(AudioClosestLoudLooping3d : AudioClosestLooping3d)
{
	referenceDistance = 15;
};

datablock AudioProfile(hl2energyBallTravelSound)
{
   filename    = $hl2Weapons::Path @ "/Sounds/EnergyBall/energy_loop.wav";
   description = AudioClosestLoudLooping3d;
   preload     = true;
};

datablock ParticleData(hl2energyBallTrailParticle)
{
   dragCoefficient      = 3;
   gravityCoefficient   = -0.0;
   inheritedVelFactor   = 1;
   constantAcceleration = 0.0;
   lifetimeMS           = 60;
   lifetimeVarianceMS   = 0;
   textureName          = $hl2Weapons::Path @ "/Models/eBall_2.png";
   spinSpeed      = 20.0;
   spinRandomMin     = -150.0;
   spinRandomMax     = 150.0;
   colors[0]     = "1 1 1 0.8";
   colors[1]     = "0.8 1 1 0.9";
   colors[2]     = "0.8 0.8 0.8 0.8";
   colors[3]     = "0.8 0.8 0.8 0.9";

   sizes[0]      = 0.35;
   sizes[1]      = 1;
   sizes[2]      = 0.35;
   sizes[3]      = 0.3;

   times[0] = 0.4;
   times[1] = 0.1;
   times[2] = 0.5;
   times[3] = 1.0;

   useInvAlpha = false;
};

datablock ParticleEmitterData(hl2energyBallTrailEmitter)
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
   particles = "hl2energyBallTrailParticle";

   //uiName = "Energy Ball Trail";
};

datablock ParticleData(hl2energyBallDebrisParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = -0.0;
   inheritedVelFactor   = 1.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 0;
   textureName          = $hl2Weapons::Path @ "/Models/spark.png";
   spinSpeed		   = 50.0;
   spinRandomMin		= 0.0;
   spinRandomMax		= 0.0;
   colors[0]     = 80/256 SPC 128/256 SPC 32/256 SPC 0.4;
   colors[1]     = 128/256 SPC 192/256 SPC 64/256 SPC 0.5;
   colors[2]     = "1 1 0 0";

   sizes[0]      = 0.1;
   sizes[1]      = 0.1;
   sizes[2]      = 0.1;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   useInvAlpha = false;
};

datablock ParticleEmitterData(hl2energyBallDebrisEmitter)
{
   ejectionPeriodMS = 50;
   periodVarianceMS = 0;
   ejectionVelocity = 0.25;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   particles = "hl2energyBallDebrisParticle";

   useEmitterColors = true;

   //uiName = "Energy Ball Bounce";
};

datablock DebrisData(hl2energyBallDebris)
{
   emitters = "hl2energyBallDebrisEmitter";

	shapeFile = "base/data/shapes/empty.dts";
	lifetime = 1;
	minSpinSpeed = -300.0;
	maxSpinSpeed = 300.0;
	elasticity = 0.5;
	friction = 0.2;
	numBounces = 10;
	staticOnMaxBounce = true;
	snapOnMaxBounce = false;
	fade = true;

	gravModifier = 1;
};

datablock ExplosionData(hl2energyBallExplosion)
{
   explosionShape = "Add-Ons/Weapon_Rocket_Launcher/explosionSphere1.dts";
   soundProfile = hl2energyBallExplosionSound;

   lifeTimeMS = 150;

   debris = hl2energyBallDebris;
   debrisNum = 15;
   debrisNumVariance = 5;
   debrisPhiMin = 0;
   debrisPhiMax = 360;
   debrisThetaMin = 0;
   debrisThetaMax = 360;
   debrisVelocity = 10;
   debrisVelocityVariance = 3;

   particleEmitter = "";
   
   faceViewer     = true;
   explosionScale = "0.1 0.1 0.1";
   
   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "3.0 10.0 3.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;
   
   // Dynamic light
   lightStartRadius = 2;
   lightEndRadius = 0;
   lightStartColor = "1 1 0 1";
   lightEndColor = "1 1 0 0";

   damageRadius = 2;
   radiusDamage = 20;

   impulseRadius = 2;
   impulseForce = 500;
};

datablock ExplosionData(hl2energyBallBounceExplosion)
{
	soundProfile = hl2energyBallBounceSound;
	explosionScale = "0.5 0.5 0.5";
	
	debris = hl2energyBallDebris;
	debrisNum = 4;
	debrisNumVariance = 1;
	debrisPhiMin = 0;
	debrisPhiMax = 360;
	debrisThetaMin = 0;
	debrisThetaMax = 360;
	debrisVelocity = 3;
	debrisVelocityVariance = 2;
};

AddDamageType("EnergyBallDirect",'<bitmap:add-ons/Projectile_Energy_Ball/ci_energyball> %1','%2 <bitmap:add-ons/Projectile_Energy_Ball/ci_energyball> %1',1,1);

datablock ProjectileData(hl2energyBallProjectile)
{
   projectileShapeName = "base/data/shapes/empty.dts";
   explosion           = hl2energyBallExplosion;
   bounceExplosion     = hl2energyBallBounceExplosion;
   particleEmitter     = hl2energyBallTrailEmitter;
   particleEmitter[2]     = hl2energyBallTrailEmitterB;
   explodeOnDeath = true;
   
   directDamage        = 1;
   directDamageType = $DamageType::EnergyBallDirect;

   brickExplosionRadius = 0;
   brickExplosionImpact = 0;             //destroy a brick if we hit it directly?
   brickExplosionForce  = 0;             
   brickExplosionMaxVolume = 0;          //max volume of bricks that we can destroy
   brickExplosionMaxVolumeFloating = 0;  //max volume of bricks that we can destroy if they aren't connected to the ground (should always be >= brickExplosionMaxVolume)

   sound = hl2energyBallTravelSound;

   muzzleVelocity      = 55;
   velInheritFactor    = 1.0;

   armingDelay         = 10000;
   lifetime            = 10000;
   fadeDelay           = 9800;
   bounceElasticity    = 0.99;
   bounceFriction      = 0.00;
   isBallistic         = true;
   gravityMod          = 0.0;

   hasLight    = true;
   lightRadius = 1.0;
   lightColor  = "0 0.5 0";

   //uiName = "Energy Ball";
};

function hl2energyBallProjectile::damage(%this,%obj,%col,%fade,%pos,%normal)
{
   if(!(%col.getType() & $TypeMasks::PlayerObjectType))
      return;
   %scale = getWord(%col.getScale(), 2);
   %directDamage = %col.dataBlock.maxDamage + (%col.dataBlock.isHealthPlayer ? %col.dataBlock.maxEnergy : 0) * %scale;
   %damageType = %this.directDamageType;
   
   %col.damage(%obj, %pos, %directDamage, %damageType);
   %col.burnPlayer(3);
   
   
   //If you were invincible e.g. spawning then don't delete them
   if(%col.getState() $= "Dead")
   {
      %rnd = getRandom(1, 2);
      serverPlay3d(hl2energyBallDisintegrateSound @ %rnd,%pos);
      %col.schedule(750,spawnExplosion,hl2energyBallProjectile,%scale*1.5);
      %col.schedule(783,delete);
   }
}

function hl2energyBallProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal)
{
   parent::onCollision(%this, %obj, %col, %fade, %pos, %normal);

   %rnd = getRandom( 1, 2 );
   serverPlay3d( hl2energyBallBounceSound @ %rnd, %pos );
}