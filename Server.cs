$hl2Weapons::Path = filePath( expandFileName( "./description.txt" ) );

$hl2Weapons::ShowAmmo = true;
$hl2Weapons::Ammo = true;
$hl2Weapons::ammoSystem = true;

$hl2Weapons::MaxAmmo["9mm"] = 150;
$hl2Weapons::AddAmmo["9mm"] = 20;

$hl2Weapons::MaxAmmo["smg"] = 270;
$hl2Weapons::AddAmmo["smg"] = 50;

$hl2Weapons::MaxAmmo["buckshot"] = 30;
$hl2Weapons::AddAmmo["buckshot"] = 10;

$hl2Weapons::MaxAmmo["rebar"] = 10;
$hl2Weapons::AddAmmo["rebar"] = 5;

$hl2Weapons::MaxAmmo["357"] = 18;
$hl2Weapons::AddAmmo["357"] = 8;

$hl2Weapons::MaxAmmo["pulse"] = 90;
$hl2Weapons::AddAmmo["pulse"] = 30;

$hl2Weapons::MaxAmmo["grenade"] = 5;
$hl2Weapons::AddAmmo["grenade"] = 1;

$hl2Weapons::MaxAmmo["rocket"] = 3;
$hl2Weapons::AddAmmo["rocket"] = 1;

datablock AudioProfile(hl2BulletHitSound1)
{
	filename    = "./Sounds/Generic/bullet_impact.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2BulletHitSound2)
{
	filename    = "./Sounds/Generic/bullet_impact2.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2BulletHitSound3)
{
	filename    = "./Sounds/Generic/bullet_impact3.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2BulletHitSound4)
{
	filename    = "./Sounds/Generic/bullet_impact4.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2fleshHitSound1)
{
	filename    = "./Sounds/Generic/flesh_impact_bullet.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2fleshHitSound2)
{
	filename    = "./Sounds/Generic/flesh_impact_bullet2.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2fleshHitSound3)
{
	filename    = "./Sounds/Generic/flesh_impact_bullet3.wav";
	description = AudioClose3d;
	preload = true;
};

datablock AudioProfile(hl2fleshHitSound4)
{
	filename    = "./Sounds/Generic/flesh_impact_bullet4.wav";
	description = AudioClose3d;
	preload = true;
};
datablock AudioProfile(hl2PickupSound)
{
	filename    = "./Sounds/ammo_pickup.wav";
	description = AudioClose3d;
	preload = true;
};
datablock AudioProfile(hl2weaponSwitchSound)
{
	filename    = "./Sounds/weaponSwitch.wav";
	description = AudioClosest3d;
	preload = true;
};
datablock AudioProfile(hl2GrenadeExplosionSound)
{
	filename    = $hl2Weapons::Path @ "/Sounds/Grenade/GrenadeExplode.wav";
	description = AudioDefault3d;
	preload = false;
};

datablock staticShapeData( gunShotShapeData )
{
	shapeFile = $hl2Weapons::Path @ "/models/shot_decal.dts";
	doColorShift = true;
	colorShiftColor = "0.5 0.55 0.5 1";
};

datablock staticShapeData( hl2TracerShapeData )
{
	shapeFile = $hl2Weapons::Path @ "/models/tracerModel.dts";
	thread = "root";
};

$error = ForceRequiredAddOn("Weapon_Gun");

if($error == $Error::AddOn_Disabled)
{
	GunItem.uiName = "";
}

if($error == $Error::AddOn_NotFound)
{
	error("ERROR: Weapon_Half-Life_2 - required add-on Weapon_Gun not found");
}
else
{
	$pattern = $hl2Weapons::Path @ "/support/*.cs";
	for ( $file = findFirstFile( $pattern ) ; $file !$= "" ; $file = findNextFile( $pattern ) )
	{
		exec( $file );
	}
	
	exec($hl2Weapons::Path @ "/scripts/grenade.cs");
	exec($hl2Weapons::Path @ "/scripts/Energy_Ball.cs");
	exec($hl2Weapons::Path @ "/scripts/Weapon_Pistol.cs");
	//Executed individualy because other weapons are dependant on those.
	
	$pattern = $hl2Weapons::Path @ "/scripts/*.cs";
	for ( $file = findFirstFile( $pattern ) ; $file !$= "" ; $file = findNextFile( $pattern ) )
	{
		if($file $= $hl2Weapons::Path @ "/scripts/grenade.cs" || $file $= $hl2Weapons::Path @ "/scripts/Weapon_Pistol.cs" || $file $= $hl2Weapons::Path @ "/scripts/Energy_Ball.cs") {
			continue;
		}
		exec( $file );
	}
	$file = "";
	$pattern = "";
}