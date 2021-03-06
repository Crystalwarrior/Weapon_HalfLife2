//sounds
datablock AudioProfile(hl2PistolFireSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Pistol/pistol_fire.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2PistolFire2Sound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Pistol/pistol_fire2.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2PistolEmptySound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Pistol/pistol_empty.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2PistolReloadSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Pistol/pistol_reload.wav";
	description = AudioClose3d;
	preload = true;
};


//shell
datablock DebrisData(hl2PistolShellDebris)
{
	shapeFile = $hl2Weapons::Path @ "/Models/shell_9mm.dts";
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

datablock ParticleData(hl2PistolSmokeParticle)
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
	colors[0]     = "0.3 0.3 0.2 0.9";
	colors[1]     = "0.1 0.1 0.1 0.0";
	sizes[0]      = 0.15;
	sizes[1]      = 0.15;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2PistolSmokeEmitter)
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
	particles = "hl2PistolSmokeParticle";

	//uiName = "hl2Pistol Smoke";
};


datablock ParticleData(hl2PistolExplosionParticle)
{
	dragCoefficient      = 1;
	gravityCoefficient   = 1;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 700;
	lifetimeVarianceMS   = 400;
	textureName          = "base/data/particles/chunk";
	spinSpeed      = 10.0;
	spinRandomMin     = -50.0;
	spinRandomMax     = 50.0;
	colors[0]     = "0.6 0.5 0.5 0.6";
	colors[1]     = "0.6 0.5 0.5 0.0";
	sizes[0]      = 0.25;
	sizes[1]      = 0.1;

	useInvAlpha = true;
};

//muzzle flash effects
datablock ParticleData(hl2PistolFlashParticle)
{
	dragCoefficient      = 3;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 25;
	lifetimeVarianceMS   = 15;
	textureName          = $hl2Weapons::Path @ "/Models/muzzleflash";
	spinSpeed      = 10.0;
	spinRandomMin     = -500.0;
	spinRandomMax     = 500.0;
	colors[0]     = "0.8 0.5 0.0 0.9";
	colors[1]     = "0.7 0.3 0.0 0.0";
	sizes[0]      = 0.5;
	sizes[1]      = 1.0;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2PistolFlashEmitter)
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
	particles = "hl2PistolFlashParticle";

	//uiName = "9mm Pistol Flash";
};
datablock ParticleEmitterData(hl2PistolExplosionEmitter)
{
	ejectionPeriodMS = 1;
	periodVarianceMS = 0;
	ejectionVelocity = 2;
	velocityVariance = 1.0;
	ejectionOffset   = 0.0;
	thetaMin         = 90;
	thetaMax         = 180;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2PistolExplosionParticle";

	useEmitterColors = true;
	//uiName = "hl2Pistol Hit Dust";
};


datablock ParticleData(hl2PistolExplosionRingParticle)
{
	dragCoefficient      = 8;
	gravityCoefficient   = -0.5;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.3;
	lifetimeMS           = 600;
	lifetimeVarianceMS   = 100;
	textureName          = "base/data/particles/smoke";
	spinSpeed      = 10.0;
	spinRandomMin     = -50.0;
	spinRandomMax     = 50.0;
	colors[0]     = "0.3 0.3 0.2 0.9";
	colors[1]     = "0.1 0.1 0.1 0.0";
	sizes[0]      = 0.1;
	sizes[1]      = 0.3;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2PistolExplosionRingEmitter)
{
	lifeTimeMS = 50;

	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 1;
	velocityVariance = 0.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 180;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	overrideAdvance = false;
	particles = "hl2PistolExplosionRingParticle";

	useEmitterColors = true;
	//uiName = "hl2Pistol Hit Flash";
};
datablock ExplosionData(hl2PistolExplosion)
{
	//explosionShape = "";
	//soundProfile = bulletHitSound;

	lifeTimeMS = 150;

	particleEmitter = hl2PistolExplosionEmitter;
	particleDensity = 5;
	particleRadius = 0.2;

	emitter[0] = hl2PistolExplosionRingEmitter;

	faceViewer     = true;
	explosionScale = "1 1 1";

	shakeCamera = false;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10.0;

	// Dynamic light
	lightStartRadius = 1;
	lightEndRadius = 1;
	lightStartColor = "0.8 0.8 0.0";
	lightEndColor = "0 0 0";
};

AddDamageType("hl2Pistol",   '<bitmap:add-ons/Weapon_HalfLife_2/Icons/CI_Pistol> %1',    '%2 <bitmap:add-ons/Weapon_HalfLife_2/Icons/CI_Pistol> %1',0.2,1);
datablock ProjectileData(hl2PistolProjectile)
{
	projectileShapeName = "Add-Ons/Weapon_Gun/bullet.dts";
	directDamage        = 0;//8;
	directDamageType    = $DamageType::hl2Pistol;
	radiusDamageType    = $DamageType::hl2Pistol;

	brickExplosionRadius = 0;
	brickExplosionImpact = false;          //destroy a brick if we hit it directly?
	// brickExplosionForce  = 10;
	// brickExplosionMaxVolume = 1;          //max volume of bricks that we can destroy
	// brickExplosionMaxVolumeFloating = 2;  //max volume of bricks that we can destroy if they aren't connected to the ground

	impactImpulse       = 0;
	verticalImpulse     = 0;
	explosion           = hl2PistolExplosion;
	particleEmitter     = ""; //bulletTrailEmitter;

	muzzleVelocity      = 200;
	velInheritFactor    = 1;

	armingDelay         = 00;
	lifetime            = 400;
	fadeDelay           = 100;
	bounceElasticity    = 0.5;
	bounceFriction      = 0.20;
	isBallistic         = false;
	gravityMod = 0.0;

	hasLight    = false;
	lightRadius = 3.0;
	lightColor  = "0 0 0.5";

	//uiName = "hl2Pistol Bullet";
};

datablock ProjectileData(hl2PistolTracerProjectile)
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
datablock ItemData(hl2PistolItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = $hl2Weapons::Path @ "/models/hl2_pistol.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "9mm Pistol";
	//iconName = "./icons/icon_Pistol";
	doColorShift = false;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	maxmag = 18;
	ammotype = "9mm";
	reload = true;

	 // Dynamic properties defined by the scripts
	image = hl2PistolImage;
	canDrop = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(hl2PistolImage)
{
	// Basic Item properties
	shapeFile = $hl2Weapons::Path @ "/models/hl2_pistol.dts";
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
	item = hl2PistolItem;
	ammo = " ";
	projectile = hl2PistolProjectile;
	projectileType = Projectile;

	raycastWeaponRange = 200;
	raycastWeaponTargets =
						 $TypeMasks::PlayerObjectType |    //AI/Players
						 $TypeMasks::StaticObjectType |    //Static Shapes
						 $TypeMasks::TerrainObjectType |    //Terrain
						 $TypeMasks::VehicleObjectType |    //Terrain
						 $TypeMasks::FXBrickObjectType;    //Bricks
	raycastExplosionProjectile = hl2PistolProjectile;
	raycastExplosionBrickSound = "";
	raycastExplosionPlayerSound = "";
	raycastDirectDamage = 8; //10
	raycastDirectDamageType = $DamageType::hl2Pistol;
	raycastSpreadAmt = 0.0006;
	raycastSpreadCount = 1;
	raycastTracerProjectile = hl2PistolTracerProjectile;
	raycastTracerShape = hl2TracerShapeData;
	raycastTracerSize = 1;
	raycastTracerColor = "0.8 0.5 0.0 1";
	raycastFromMuzzle = true;

	casing = hl2PistolShellDebris;
	shellExitDir        = "0.5 -1.3 0.5";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;   
	shellVelocity       = 7.0;

	//melee particles shoot from eye node for consistancy
	melee = false;
	//raise your arm up or not
	armReady = true;

	doColorShift = false;
	colorShiftColor = hl2PistolItem.colorShiftColor;//"0.400 0.196 0 1.000";

	//casing = " ";

	// Images have a state system which controls how the animations
	// are run, which sounds are played, script callbacks, etc. This
	// state system is downloaded to the client so that clients can
	// predict state changes and animate accordingly.  The following
	// system supports basic ready->fire->reload transitions as
	// well as a no-ammo->dryfire idle state.

	// Initial start up state
	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.15;
	stateTransitionOnTimeout[0]      = "AmmoCheck";
	stateSound[0]                    = "";

	stateName[1]                     = "Ready";
	stateTransitionOnTriggerDown[1]  = "Fire";
	stateTransitionOnNoAmmo[1]       = "Empty";
	stateAllowImageChange[1]         = true;
	stateSequence[1]                 = "root";

	stateName[2]                     = "Fire";
	stateTransitionOnTriggerUp[2]    = "AmmoCheck";
	stateTimeoutValue[2]             = 0.13;
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
	stateSound[4]                    = hl2PistolReloadSound;

	stateName[5]                     = "ReloadReady";
	stateTransitionOnTimeout[5]      = "CheckChamber";
	stateTimeoutValue[5]             = 0.1;
	stateAllowImageChange[5]         = true;
	stateScript[5]                   = "onReload";

	stateName[6]                     = "Empty";
	stateTransitionOnTriggerDown[6]  = "EmptyFire";
	stateAllowImageChange[6]         = true;
	stateScript[6]                   = "onEmpty";
	stateTransitionOnAmmo[6]         = "Reload";
	//stateSequence[6]                 = "noammo";

	stateName[7]                     = "EmptyFire";
	stateTransitionOnTriggerUp[7]    = "Empty";
	stateTimeoutValue[7]             = 0.13;
	stateAllowImageChange[7]         = false;
	stateWaitForTimeout[7]           = true;
	stateSound[7]                    = hl2PistolEmptySound;
	stateSequence[7]                 = "noammo_fire";

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

function hl2PistolImage::onReloadStart( %this, %obj, %slot )
{
	%obj.playThread(2,shiftRight);
	%obj.schedule(250, "playThread", "2", "shiftRight");
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2PistolImage::onAmmoCheck( %this, %obj, %slot )
{
	hl2AmmoCheck(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2PistolImage::onReload( %this, %obj, %slot )
{
	%obj.playThread(2,plant);
	hl2AmmoOnReload(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2PistolImage::onCock( %this, %obj, %slot )
{
	%obj.playThread(2,shiftLeft);
	%obj.setImageAmmo(0,1);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2PistolImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,0);
}
function hl2PistolImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,-1);
}

function hl2PistolImage::onEmpty(%this,%obj,%slot)
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

function hl2PistolImage::onFire( %this, %obj, %slot )
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

	%obj.playThread(2, shiftRight);
	%obj.playThread(3, shiftLeft);

	serverPlay3d( hl2PistolFire2Sound, %obj.getHackPosition() );
}

function hl2PistolImage::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit )
{
	if( !( %col.getType() & $typeMasks::playerObjectType || %col.getType() & $typeMasks::corpseObjectType ) )
	{
		%rnd = getRandom( 1, 4 );
		serverPlay3d( hl2BulletHitSound @ %rnd, %pos );
	}
	else
	{
		%rnd = getRandom( 1, 4 );                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
		serverPlay3d( hl2FleshHitSound @ %rnd, %pos );
	}

	if( !(%col.getType() & $typeMasks::playerObjectType) && !(%col.getType & $TypeMasks::vehicleObjectType) )
	{
		spawnDecal(gunShotShapeData, vectorAdd(%pos, vectorScale(%normal, 0.02)), %normal, 1);
	}

	parent::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit );
}

function hl2PistolImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
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


// function hl2PistolProjectile::damage( %this, %obj, %col, %fade, %pos, %normal )
// {
//    %damage = %this.directDamage;
//    %headshot = matchBodyArea( getHitbox( %obj, %col, %pos ), $headTest );

//    if ( %headshot )
//    {
//       %damage *= 3;
//    }

//    %col.damage( %obj, %pos, %damage, %this.directDamageType );
// }

// function hl2PistolProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal)
// {
//    parent::onCollision(%this, %obj, %col, %fade, %pos, %normal);

//    if( !( %col.getType() & $typeMasks::playerObjectType || %col.getType() & $typeMasks::corpseObjectType ) )
//    {
//       %sound = getRandom( 1, 4 );
//       switch(%sound)
//       {
//          case 1: serverPlay3d( hl2BulletHitSound, %pos );
//          case 2: serverPlay3d( hl2BulletHitSound2, %pos );
//          case 3: serverPlay3d( hl2BulletHitSound3, %pos );
//          case 4: serverPlay3d( hl2BulletHitSound4, %pos );
//       }
//    }
//    else
//    {
//       %sound = getRandom( 1, 4 );
//       switch(%sound)
//       {
//          case 1: serverPlay3d( hl2FleshHitSound, %pos );
//          case 2: serverPlay3d( hl2FleshHitSound2, %pos );
//          case 3: serverPlay3d( hl2FleshHitSound3, %pos );
//          case 4: serverPlay3d( hl2FleshHitSound4, %pos );
//       }
//    }
// }