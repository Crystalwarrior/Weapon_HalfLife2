//	+-----------------------------------+
//	|		HL2 Weapons Pack			|
//	|		by Zapk & Aware14			|
//	+-----------------------------------+
//	|		hl2Crowbar.cs					|
//	+-----------------------------------+

//audio
datablock AudioProfile(hl2CrowbarSwingSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crowbar/crowbar_swing.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock AudioProfile(hl2CrowbarHitSound1)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crowbar/crowbar_impact1.wav";
	description = AudioClosest3d;
	preload = true;
};
datablock AudioProfile(hl2CrowbarHitSound2)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Crowbar/crowbar_impact2.wav";
	description = AudioClosest3d;
	preload = true;
};


//projectile
AddDamageType("hl2Crowbar",   '<bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Crowbar> %1',    '%2 <bitmap:Add-Ons/Weapon_HalfLife2/Icons/CI_Crowbar> %1',0.5,1);

datablock ExplosionData(hl2CrowbarExplosion : SwordExplosion)
{
	soundProfile = "";
};

datablock ProjectileData(hl2CrowbarProjectile)
{
	directDamage        = 0;
	directDamageType  = $DamageType::hl2Crowbar;
	radiusDamageType  = $DamageType::hl2Crowbar;
	explosion           = hl2CrowbarExplosion;
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

	//uiName = "Crowbar Slice";
};


//////////
// item //
//////////
datablock ItemData(hl2CrowbarItem)
{
	category = "Weapon";  // Mission editor category
	className = "Weapon"; // For inventory system

	 // Basic Item Properties
	shapeFile = $hl2Weapons::Path @ "/Models/Crowbar.dts";
	mass = 1;
	density = 0.2;
	elasticity = 0.2;
	friction = 0.6;
	emap = true;

	//gui stuff
	uiName = "Crowbar";
	iconName = $hl2Weapons::Path @ "/Icons/Icon_Crowbar";
	doColorShift = true;
	colorShiftColor = "0.471 0 0 1.000";
  
	 // Dynamic properties defined by the scripts
	image = hl2CrowbarImage;
	canDrop = true;
};

////////////////
//weapon image//
////////////////
datablock ShapeBaseImageData(hl2CrowbarImage)
{
	// Basic Item properties
	shapeFile = $hl2Weapons::Path @ "/Models/Crowbar.dts";
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

	eyeOffset = 0; //"0.7 1.2 -0.25";

	// Add the WeaponImage namespace as a parent, WeaponImage namespace
	// provides some hooks into the inventory system.
	className = "WeaponImage";

	// Projectile && Ammo.
	item = hl2CrowbarItem;
	ammo = " ";
	projectile = hl2CrowbarProjectile;
	projectileType = Projectile;

	meleeRange = 4;
	meleeAngle = 0.5;
	raycastWeaponRange = 4;
	raycastWeaponTargets =
						 $TypeMasks::PlayerObjectType |    //AI/Players
						 $TypeMasks::StaticObjectType |    //Static Shapes
						 $TypeMasks::TerrainObjectType |    //Terrain
						 $TypeMasks::VehicleObjectType |    //Terrain
						 $TypeMasks::FXBrickObjectType;    //Bricks
	raycastExplosionProjectile = hl2CrowbarProjectile;
	raycastDirectDamage = 25;
	raycastDirectDamageType = $DamageType::hl2Crowbar;

	//melee particles shoot from eye node for consistancy
	melee = true;
	doRetraction = false;
	//raise your arm up or not
	armReady = true;

	//casing = " ";
	doColorShift = true;
	colorShiftColor = "0.471 0 0 1.000";

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
	stateSound[0]                    = "";

	stateName[1]                     = "Ready";
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
	stateTimeoutValue[4]             = 0.3;
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
	stateTimeoutValue[6]             = 0.1;
	stateAllowImageChange[6]         = false;
	stateWaitForTimeout[6]		       = true;
	stateSequence[6]                 = "StopFire";
	stateScript[6]                   = "onStopFire";
};

function hl2CrowbarImage::onPreFire(%this, %obj, %slot)
{
	%obj.playthread(2, shiftAway);
}

function hl2CrowbarImage::onFire(%this, %obj, %slot)
{
	parent::onFire(%this, %obj, %slot);
	serverPlay3d( hl2CrowbarSwingSound, %obj.getHackPosition() );
	%obj.playthread(2, shiftTo);
	%obj.playthread(3, shiftleft); 
}

function hl2CrowbarImage::onStopFire(%this, %obj, %slot)
{
	%obj.setImageAmmo(0, 1);
}

function hl2CrowbarImage::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit )
{
	cancel(%obj.crowbarSchedule);
	%obj.setImageAmmo(0, 0);
	if( !( %col.getType() & $typeMasks::playerObjectType || %col.getType() & $typeMasks::corpseObjectType ) )
	{
		%rnd = getRandom( 1, 4 );
		serverPlay3d( hl2BulletHitSound @ %rnd, %pos );
		%rnd = getRandom( 1, 2 );
		serverPlay3d( hl2CrowbarHitSound @ %rnd, %pos );
	}
	else
	{
		%rnd = getRandom( 1, 4 );
		serverPlay3d( hl2FleshHitSound @ %rnd, %pos );
	}

	if( !(%col.getType() & $typeMasks::playerObjectType) && !(%col.getType & $TypeMasks::vehicleObjectType) )
	{
		spawnDecal(gunShotShapeData, vectorAdd(%pos, vectorScale(%normal, 0.02)), %normal);
	}

	%obj.crowbarSchedule = %obj.schedule(600, setImageAmmo, 0, 1);
	parent::onHitObject( %this, %obj, %slot, %col, %pos, %normal, %shotVec, %crit );
}