//	+-----------------------------------+
//	|		HL2 Weapons Pack			|
//	|		by Zapk & Aware14			|
//	+-----------------------------------+
//	|		hl2Crossbow.cs					|
//	+-----------------------------------+

//audio
datablock AudioProfile(hl2CrossbowFireSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crossbow/CrossbowFire.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2CrossbowHitSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crossbow/CrossbowHit.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2CrossbowHitFleshSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crossbow/hitbod1.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2CrossbowHitFleshSound2)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crossbow/hitbod2.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2CrossbowReloadSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crossbow/reload1.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2CrossbowBoltLoadSound1)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crossbow/bolt_load1.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2CrossbowBoltLoadSound2)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crossbow/bolt_load2.wav";
	description = AudioClose3d;
	preload = true;
};

datablock ExplosionData(hl2CrossbowStickExplosion)
{
	//explosionShape = "";
	soundProfile = hl2CrossbowHitSound;

	lifeTimeMS = 150;

	particleEmitter = arrowStickExplosionEmitter;
	particleDensity = 10;
	particleRadius = 0.2;

	emitter[0] = "";

	faceViewer     = true;
	explosionScale = "1 1 1";

	shakeCamera = false;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "1.0 1.0 1.0";
	camShakeDuration = 0.5;
	camShakeRadius = 10.0;

	// Dynamic light
	lightStartRadius = 0;
	lightEndRadius = 1;
	lightStartColor = "0.3 0.6 0.7";
	lightEndColor = "0 0 0";
};

AddDamageType("hl2Crossbow",   '<bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Crossbow> %1',    '%2 <bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Crossbow> %1',0.5,1);
datablock ProjectileData(hl2CrossbowProjectile)
{
	projectileShapeName = $hl2Weapons::Path @ "/Models/crossbow_bolt.dts";

	directDamage        = 100;
	directDamageType    = $DamageType::hl2Crossbow;

	radiusDamage        = 0;
	damageRadius        = 0;
	radiusDamageType    = $DamageType::hl2Crossbow;

	explosion             = arrowExplosion;
	stickExplosion        = hl2CrossbowStickExplosion;
	bloodExplosion        = hl2CrossbowStickExplosion;
	//particleEmitter       = arrowTrailEmitter;
	explodeOnPlayerImpact = true;
	explodeOnDeath        = true;  

	armingDelay         = 10000;
	lifetime            = 10000;
	fadeDelay           = 9500;

	isBallistic         = true;
	bounceAngle         = 170;
	minStickVelocity    = 10;
	bounceElasticity    = 0.2;
	bounceFriction      = 0.01;   
	gravityMod = 0.01;

	hasLight    = false;
	lightRadius = 3.0;
	lightColor  = "0 0 0.5";

	muzzleVelocity      = 150;
	velInheritFactor    = 0.4;

	uiName = "Crossbow Bolt";
};

//////////
// item //
//////////
datablock ItemData(hl2CrossbowItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = $hl2Weapons::Path @ "/Models/hl2_crossbow.dts";
	rotate = false;
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "Crossbow";
	iconName = $hl2Weapons::Path @ "/Icons/Icon_Crossbow";
	doColorShift = true;
	colorShiftColor = "0.25 0.25 0.25 1.000";

	maxmag = 1;
	ammotype = "rebar";
	reload = true;

	 // Dynamic properties defined by the scripts
	image = hl2CrossbowImage;
	canDrop = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(hl2CrossbowImage)
{
	// Basic Item properties
	shapeFile = $hl2Weapons::Path @ "/Models/hl2_crossbow.dts";
	emap = true;

	// Specify mount point & offset for 3rd person, and eye offset
	// for first person rendering.
	mountPoint = 0;
	offset = "0 0 -0.15";
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
	item = hl2CrossbowItem;
	ammo = " ";
	projectile = hl2CrossbowProjectile;
	projectileType = Projectile;

	//melee particles shoot from eye node for consistancy
	melee = false;
	//raise your arm up or not
	armReady = true;

	doColorShift = true;
	colorShiftColor = hl2CrossbowItem.colorShiftColor;//"0.400 0.196 0 1.000";

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
	stateScript[1]					 = "onReady";

	stateName[2]                     = "Fire";
	stateTransitionOnTriggerUp[2]    = "AmmoCheck";
	stateTimeoutValue[2]             = 0.65;
	stateFire[2]                     = true;
	stateAllowImageChange[2]         = false;
	stateSequence[2]                 = "Fire";
	stateScript[2]                   = "onFire";
	stateWaitForTimeout[2]           = true;
	stateEmitter[2]                  = gunFlashEmitter;
	stateSound[2]                    = hl2CrossbowFireSound;
	stateEmitterTime[2]              = 0.05;
	stateEmitterNode[2]              = "muzzleNode";
	stateEjectShell[2]               = true;

	stateName[3]                     = "AmmoCheck";
	stateTransitionOnTimeout[3]      = "Ready";
	stateAllowImageChange[3]         = true;
	//stateSequence[3]                 = "Empty";
	stateScript[3]                   = "onAmmoCheck";

	stateName[4]                     = "Reload";
	stateTransitionOnTimeout[4]      = "ReloadReady";
	stateTimeoutValue[4]             = 1.8;
	stateAllowImageChange[4]         = true;
	stateSequence[4]                 = "Arm";
	stateScript[4]                   = "onReloadStart";

	stateName[5]                     = "ReloadReady";
	stateTransitionOnTimeout[5]      = "CheckChamber";
	stateTimeoutValue[5]             = 0.5;
	stateAllowImageChange[5]         = true;
	stateSequence[5]                 = "Reload";
	stateScript[5]                   = "onReload";

	stateName[6]                     = "Empty";
	//stateTransitionOnTriggerDown[6]  = "EmptyFire";
	stateAllowImageChange[6]         = true;
	stateTransitionOnAmmo[6]         = "Reload";
	stateSequence[6]                 = "Empty";
	stateScript[6]					 = "Empty";

	stateName[7]                     = "EmptyFire";
	stateTransitionOnTriggerUp[7]    = "AmmoCheck";
	stateScript[7]                   = "onEmpty";
	stateTimeoutValue[7]             = 0.13;
	stateAllowImageChange[7]         = false;
	stateWaitForTimeout[7]           = true;
	stateSound[7]                    = hl2PistolEmptySound;
	stateSequence[7]                 = "Empty";

	stateName[8]                     = "CheckChamber";
	stateTransitionOnTimeOut[8]      = "Ready";
	stateTransitionOnNoAmmo[8]       = "Cocking";
	stateAllowImageChange[8]         = true;
	stateScript[8]					 = "CheckChamber";
 
	stateName[9]                     = "Cocking";
	stateTransitionOnTimeOut[9]      = "Ready";
	stateTimeoutValue[9]             = 0.1;
	stateAllowImageChange[9]         = true;
	stateWaitForTimeout[9]           = true;
	stateSound[9]                    = "";
	stateScript[9]                   = "onCock";
};

function hl2CrossbowImage::onReloadStart( %this, %obj, %slot )
{
	%obj.playThread(2,shiftleft);
	announce("onReloadStart");
	hl2DisplayAmmo(%this,%obj,%slot);
	serverPlay3d( hl2CrossbowReloadSound, %obj.getHackPosition() );
}

function hl2CrossbowImage::onAmmoCheck( %this, %obj, %slot )
{
	announce("onAmmoCheck");
	hl2AmmoCheck(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
}

function hl2CrossbowImage::onReload( %this, %obj, %slot )
{
	announce("onReload");
	%obj.playThread(2,plant);
	hl2AmmoOnReload(%this,%obj,%slot);
	hl2DisplayAmmo(%this,%obj,%slot);
	%rnd = getRandom(1,2);
	serverPlay3d( hl2CrossbowBoltLoadSound @ %rnd, %obj.getHackPosition() );
}

function hl2CrossbowImage::onCock( %this, %obj, %slot )
{
	//%obj.playThread(2,shiftLeft);
	%obj.setImageAmmo(0,1);
	announce("onCock");
}

function hl2CrossbowImage::onMount( %this, %obj, %slot )
{
	 parent::onMount(%this,%obj,%slot);
	 announce("mounted");
	 hl2DisplayAmmo(%this,%obj,%slot,0);
}
function hl2CrossbowImage::onUnMount( %this, %obj, %slot )
{
	 parent::onUnMount(%this,%obj,%slot);
	 announce("unMounted");
	 hl2DisplayAmmo(%this,%obj,%slot,-1);
}

function hl2CrossbowImage::onFire(%this,%obj,%slot)
{
	announce("fire");
	if(%obj.getDamagePercent() < 1.0)
		%obj.playThread(2, shiftAway);

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
}
function hl2CrossbowImage::onEmpty(%this,%obj,%slot)
{
	announce("onEmpty");
	if( $hl2Weapons::Ammo && %obj.toolAmmo[%this.item.ammotype] < 1 )
	{
		return;
	}

	if(%obj.toolMag[%obj.currTool] < 1)
	{
		serverCmdLight(%obj.client);
	}
}

function hl2CrossbowImage::Empty(%this,%obj,%slot)
{
	announce("empty");
}

function hl2CrossbowImage::onReady(%this,%obj,%slot)
{
	announce("ready");
}

function hl2CrossbowImage::CheckChamber(%this,%obj,%slot)
{
	announce("CheckChamber");
}

function hl2CrossbowProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal)
{
	parent::onCollision(%this, %obj, %col, %fade, %pos, %normal);

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
 
		%rnd = getRandom( 1, 2 );
		serverPlay3d( hl2CrossbowHitFleshSound @ %rnd, %pos );
	}
	
	if( !(%col.getType() & $typeMasks::playerObjectType) && !(%col.getType & $TypeMasks::vehicleObjectType) )
	{
		spawnDecal(gunShotShapeData, vectorAdd(%pos, vectorScale(%normal, 0.02)), %normal);
	}
}