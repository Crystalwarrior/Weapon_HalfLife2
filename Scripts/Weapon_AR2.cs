//hl2AR2Gun.cs

//audio
datablock AudioProfile(hl2AR2FireSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/AR2/AR2_fire.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2AR2ChargeSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/AR2/AR2_altfire.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2AR2EmptySound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/AR2/AR2_empty.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2AR2ReloadSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/AR2/AR2_reload.wav";
	description = AudioClose3d;
	preload = true;
};

datablock staticShapeData( ar2MuzzleShapeData )
{
	shapeFile = $hl2Weapons::Path @ "/models/ar2muzzle_decal.dts";
	doColorShift = false;
};

//muzzle flash effects
datablock ParticleData(hl2AR2GunFlashParticle)
{
	dragCoefficient      = 0;
	gravityCoefficient   = 0;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 50; //25
	lifetimeVarianceMS   = 15; //15
	textureName          =$hl2Weapons::Path @ "/Models/ar2_muzzle";
	spinSpeed		= 10.0;
	spinRandomMin		= -20.0;
	spinRandomMax		= 20.0;
	colors[0]     = "1 1 1 1";//"0.68 0.8 0.48 0.4";
	colors[1]     = "0.8 1 1 0.5";//"0.48 0.98 0.59 0.4";
	colors[2]     = "0.8 1 1 0.2";//"0.48 0.98 0.59 0.4";
	sizes[0]      = 0.75;
	sizes[1]      = 0.5;
	sizes[2]      =  0.3;
	//times[0]       = 0.0;
	//times[1]       = 0.30;
	//times[2]       = 0.75;

	useInvAlpha = false;
};
datablock ParticleEmitterData(hl2AR2GunFlashEmitter)
{
	ejectionPeriodMS = 2;
	periodVarianceMS = 0;
	ejectionVelocity = 2.0; //1.0
	velocityVariance = 1.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0;
	thetaMax         = 0;//90
	phiReferenceVel  = 0;
	phiVariance      = 0;//360
	overrideAdvance = false;
	particles = "hl2AR2GunFlashParticle";

	//uiName = "AR2Gun Flash";
};

datablock ParticleData(hl2AR2TracerParticle)
{
	textureName          = "base/data/particles/dot";
	dragCoefficient      = 10;
	gravityCoefficient   = 0.0;
	inheritedVelFactor   = 0.0;
	windCoefficient      = 0;
	constantAcceleration = 0;
	lifetimeMS           = 100;
	lifetimeVarianceMS   = 0;
	spinSpeed     = 0;
	spinRandomMin = -90.0;
	spinRandomMax =  90.0;
	useInvAlpha   = false;

	colors[0]	= "0.28 0.98 0.39 0.4";
	colors[1]	= "0.48 0.98 0.59 0.2";
	colors[2]	= "0.48 0.98 0.59 0.0";

	sizes[0]	= 0.25;
	sizes[1]	= 0.2;
	sizes[2]	= 0;

	times[0]	= 0;
	times[1]	= 0.2;
	 times[2]	= 1.0;
};
datablock ParticleEmitterData(hl2AR2TracerEmitter)
{
	//lifeTimeMS = 25;

	ejectionPeriodMS = 2; //3
	periodVarianceMS = 0;
	ejectionVelocity = 0;
	velocityVariance = 0.0;
	ejectionOffset   = 0.0;
	thetaMin         = 0; //89
	thetaMax         = 90; //90

	overrideAdvance = false;
	particles = "hl2AR2TracerParticle";

	useEmitterColors = true;
	//uiName = "hl2AR2 Tracer Emitter";
};

datablock ExplosionData(hl2AR2GunExplosion : hl2PistolExplosion)
{
	lifeTimeMS = 50;

	particleEmitter = hl2PistolExplosionEmitter;
	particleDensity = 5;
	particleRadius = 0.2;

	emitter[0] = "";//hl2PistolExplosionRingEmitter;

	// Dynamic light
	lightStartRadius = 0;
	lightEndRadius = 0;
	lightStartColor = "0 0 0";
	lightEndColor = "0 0 0";
};

AddDamageType("hl2AR2Gun",   '<bitmap:add-ons/Weapon_HalfLife2/Icons/CI_AR2Gun> %1',    '%2 <bitmap:add-ons/Weapon_HalfLife2/Icons/CI_AR2Gun> %1',0.2,1);
datablock ProjectileData(hl2AR2GunProjectile : hl2PistolProjectile)
{
	explosion           = hl2AR2GunExplosion;

	hasLight    = true;
	lightRadius = 1.0;
	lifeTime = 5000;
	lightColor  = "0 0.5 0.5";
};

//////////
// item //
//////////
datablock ItemData(hl2AR2GunItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = $hl2Weapons::Path @ "/Models/AR2Gun.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "AR2 Pulse Rifle";
	iconName = $hl2Weapons::Path @ "/Icons/icon_hl2AR2Gun";
	doColorShift = true;
	colorShiftColor = "0.27 0.28 0.37 1.000";

	 // Dynamic properties defined by the scripts
	image = hl2AR2GunImage;
	canDrop = true;

	maxmag = 30;
	ammotype = "pulse";
	altmaxmag = 3;
	altammotype = "energy"; //for ammo item reference
	reload = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(hl2AR2GunImage)
{
	// Basic Item properties
	shapeFile = $hl2Weapons::Path @ "/Models/AR2Gun.dts";
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
	item = hl2AR2GunItem;
	ammo = " ";
	projectile = hl2AR2GunProjectile;
	projectileType = Projectile;

	//casing = GunShellDebris;
	shellExitDir        = "1.0 -1.3 1.0";
	shellExitOffset     = "0 0 0";
	shellExitVariance   = 15.0;	
	shellVelocity       = 7.0;
	
	raycastWeaponRange = 200; //varies
	raycastWeaponTargets =
					$TypeMasks::PlayerObjectType |    //AI/Players
					$TypeMasks::StaticObjectType |    //Static Shapes
					$TypeMasks::TerrainObjectType |    //Terrain
					$TypeMasks::VehicleObjectType |    //Terrain
					$TypeMasks::FXBrickObjectType;    //Bricks
	raycastExplosionProjectile = hl2AR2GunProjectile;
	raycastExplosionBrickSound = "";
	raycastExplosionPlayerSound = "";
	raycastDirectDamage = 11;
	raycastDirectDamageType = $DamageType::hl2AR2Gun;
	raycastTracerProjectile = "";//hl2AR2GunTracerProjectile;
	raycastTracerShape = hl2TracerShapeData;
	raycastTracerSize = 2;
	raycastTracerColor = "0.68 0.8 0.48 1";
	raycastSpreadAmt = 0.001; //varies
	raycastSpreadCount = 1;
	raycastFromMuzzle = true;

	//melee particles shoot from eye node for consistancy
	melee = false;
	//raise your arm up or not
	armReady = true;

	doColorShift = true;
	colorShiftColor = hl2AR2GunItem.colorShiftColor;//"0.400 0.196 0 1.000";

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
	stateSequence[0]				 = "Root";

	stateName[1]                     = "Ready";
	stateTransitionOnTriggerDown[1]  = "Fire";
	stateTransitionOnNoAmmo[1]       = "Empty";
	stateAllowImageChange[1]         = true;
	stateSequence[1]                 = "ready";

	stateName[2]                     = "Fire";
	stateTransitionOnTimeOut[2]      = "AmmoCheck";
	stateSound[2]                    = hl2AR2FireSound;
	stateTimeoutValue[2]             = 0.1;
	stateFire[2]                     = true;
	stateAllowImageChange[2]         = false;
	stateSequence[2]                 = "Fire";
	stateScript[2]                   = "onFire";
	stateWaitForTimeout[2]           = true;
	stateEmitter[2]                  = hl2AR2GunFlashEmitter;
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
	stateSequence[4]				 = "Reload";
	stateSound[4]                    = hl2AR2ReloadSound;

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

	stateName[7]                     = "EmptyFire";
	stateTransitionOnTriggerUp[7]    = "Empty";
	stateTimeoutValue[7]             = 0.13;
	stateAllowImageChange[7]         = false;
	stateWaitForTimeout[7]           = true;
	stateSound[7]                    = hl2AR2EmptySound;

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

function hl2AR2GunImage::onReloadStart( %this, %obj, %slot )
{
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2AR2GunImage::onAmmoCheck( %this, %obj, %slot )
{
	hl2AmmoCheck(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2AR2GunImage::onReload( %this, %obj, %slot )
{
	hl2AmmoOnReload(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2AR2GunImage::onCock( %this, %obj, %slot )
{
	%obj.setImageAmmo(0,1);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2AR2GunImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,0);
}
function hl2AR2GunImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,-1);
}

function hl2AR2GunImage::onEmpty(%this,%obj,%slot)
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

function hl2AR2GunImage::onFire( %this, %obj, %slot )
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

function hl2AR2GunImage::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit )
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

	%decal = spawnDecal(ar2MuzzleShapeData, vectorAdd(%pos, vectorScale(%normal, 0.02)), %normal, 2.5, true);
	%decal.schedule(16, playThread, 0, "root");
	%decal.schedule(100, delete);

	if( !(%col.getType() & $typeMasks::playerObjectType) && !(%col.getType & $TypeMasks::vehicleObjectType) )
	{
		spawnDecal(gunShotShapeData, vectorAdd(%pos, vectorScale(%normal, 0.02)), %normal);

	}
	parent::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit );
}

function hl2AR2GunImage::onRaycastDamage(%this,%obj,%slot,%col,%pos,%normal,%shotVec,%crit)
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

package hl2AR2AltFire
{
	function Armor::onTrigger(%this, %obj, %slot, %val)
		{
		if(%obj.getMountedImage(0) $= hl2AR2GunImage.getID() && %slot $= 4 && %val)
		{
			if(%obj.getImageState(0) $= "Ready" || %obj.getImageState(0) $= "Empty")
			{
				%image = %obj.getMountedimage(0);
				if(%obj.toolAltMag[%obj.tool[%obj.currtool].altammotype] <= 0)
				{
					serverPlay3D(hl2AR2EmptySound,%obj.getPosition());
					return;
				}
				hl2DisplayAmmo(%this, %obj, %obj.currTool);
				%obj.unMountImage(0);
				%obj.mountImage(hl2AR2GunAltFireImage, 0);
			}
		}
		Parent::onTrigger(%this, %obj, %slot, %val);
		}
};
ActivatePackage(hl2AR2AltFire);

datablock ShapeBaseImageData(hl2AR2GunAltFireImage : hl2AR2GunImage)
{
	projectile = hl2energyBallProjectile;
	raycastWeaponRange = "";

	stateName[0]                     = "Activate";
	stateTimeoutValue[0]             = 0.15;
	stateTransitionOnTimeout[0]      = "Charge";
	stateAllowImageChange[0]		 = "false";
	stateSequence[0]				 = "Root";

	stateName[1]					 = "Charge";
	stateTimeoutValue[1]			 = 0.48;
	stateTransitionOnTimeout[1]		 = "Fire";
	stateWaitForTimeout[1]			 = true;
	stateAllowImageChange[1]		 = false;
	stateSound[1]                    = hl2AR2ChargeSound;

	stateName[2]                     = "Fire";
	stateTransitionOnTimeOut[2]      = "Wait";
	//stateSound[2]                    = hl2AR2FireSound;
	stateTimeoutValue[2]             = 0.1;
	stateFire[2]                     = true;
	stateAllowImageChange[2]         = false;
	stateSequence[2]                 = "Fire";
	stateScript[2]                   = "onFire";
	stateWaitForTimeout[2]           = true;
	stateEmitter[2]                  = hl2AR2GunFlashEmitter;
	stateEmitterTime[2]              = 0.05;
	stateEmitterNode[2]              = "muzzleNode";
	stateEjectShell[2]               = true;

	stateName[3]					 = "Wait";
	stateTransitionOnTimeout[3]		 = "Done";
	stateAllowImageChange[3]		 = false;
	stateTimeoutValue[3]			 = 0.3;

	stateName[4]					 = "Done";
	stateAllowImageChange[4]		 = true;
	stateSequence[4]				 = "Ready";
	stateScript[4]					 = "onDone";
};

function hl2AR2GunAltFireImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 %obj.playThread(2, plant);
	 hl2DisplayAmmo(%this,%obj,%slot,0);
}
function hl2AR2GunAltFireImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 hl2DisplayAmmo(%this,%obj,%slot,-1);
}

function hl2AR2GunAltFireImage::onFire(%this, %obj, %slot)
{
	parent::onFire(%this, %obj, %slot);
	%obj.playThread(2, jump);
	%obj.toolAltMag[%obj.tool[%obj.currtool].altammotype]--;
	hl2DisplayAmmo(%this, %obj, %slot);
}

function hl2AR2GunAltFireImage::onDone(%this, %obj, %slot)
{
	%obj.mountImage(hl2AR2GunImage, 0);
}