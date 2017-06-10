datablock ItemData(hl2AmmoPileItem : hammerItem)
{
	shapeFile = $hl2Weapons::Path @ "/Models/smg_ammobox.dts";
	uiName = "Ammo Pile [HL2]";
	iconName = "";
	image = "";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";
	canPickUp = true;
	ammoBox = true;
	ammoType = "ALL";
};
datablock ItemData(hl2Ammo9mmItem : hammerItem)
{
	shapeFile = $hl2Weapons::Path @ "/Models/smg_ammobox.dts";
	uiName = "Ammo, 9mm [HL2]";
	iconName = "";
	image = "";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";
	canPickUp = true;
	ammoBox = true;
	ammoType = "9mm";
};
datablock ItemData(hl2AmmoSMGItem : hammerItem)
{
	shapeFile = $hl2Weapons::Path @ "/Models/smg_ammobox.dts";
	uiName = "Ammo, SMG [HL2]";
	iconName = "";
	image = "";
	doColorShift = true;
	colorShiftColor = "0.5 0.7 0.55 1";
	canPickUp = true;
	ammoBox = true;
	ammoType = "smg";
};
datablock ItemData(hl2AmmoBuckshotItem : hammerItem)
{
	shapeFile = $hl2Weapons::Path @ "/Models/buckshot_ammo.dts";
	uiName = "Ammo, Buckshot [HL2]";
	iconName = "";
	image = "";
	doColorShift = false;
	colorShiftColor = "0.471 0.471 0.47w1 1.000";
	canPickUp = true;
	ammoBox = true;
	ammoType = "buckshot";
};
datablock ItemData(hl2AmmoRebarItem : hammerItem)
{
	shapeFile = "base/data/shapes/brickweapon.dts";
	uiName = "Ammo, Crossbow [HL2]";
	iconName = "";
	image = "";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";
	canPickUp = true;
	ammoBox = true;
	ammoType = "rebar";
};
datablock ItemData(hl2Ammo357Item : hammerItem)
{
	shapeFile = $hl2Weapons::Path @ "/Models/buckshot_ammo.dts";
	uiName = "Ammo, 357 [HL2]";
	iconName = "";
	image = "";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";
	canPickUp = true;
	ammoBox = true;
	ammoType = "357";
};
datablock ItemData(hl2AmmoPulseItem : hammerItem)
{
	shapeFile = "base/data/shapes/brickweapon.dts";
	uiName = "Ammo, Pulse [HL2]";
	iconName = "";
	image = "";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";
	canPickUp = true;
	ammoBox = true;
	ammoType = "pulse";
};
datablock ItemData(hl2AmmoRocketItem : hammerItem)
{
	shapeFile = "base/data/shapes/brickweapon.dts";
	uiName = "Ammo, Rocket [HL2]";
	iconName = "";
	image = "";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";
	canPickUp = true;
	ammoBox = true;
	ammoType = "rocket";
};

datablock ItemData(hl2AmmoRifleNadeItem : hammerItem)
{
	shapeFile = "base/data/shapes/brickweapon.dts";
	uiName = "Ammo, Rifle Grenades [HL2]";
	iconName = "";
	image = "";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";
	canPickUp = true;
	ammoBox = true;
	altAmmoType = "riflenade";
	altAmmoAdd = 1;
};
datablock ItemData(hl2AmmoEnergyItem : hammerItem)
{
	shapeFile = "base/data/shapes/brickweapon.dts";
	uiName = "Ammo, Energy Balls [HL2]";
	iconName = "";
	image = "";
	doColorShift = true;
	colorShiftColor = "0.471 0.471 0.471 1.000";
	canPickUp = true;
	ammoBox = true;
	altAmmoType = "energy";
	altAmmoAdd = 1;
};

function Player::addItem(%player, %image, %client)
{
	// if(%image.item.ammoBox == true)
	// {
	// 	if(%image.item.ammoBox && ( %image.item.ammoType !$= "" || %image.item.altAmmoType !$= "" ) && %col.canPickup && %player.getDamagePercent() < 1)
	// 	{
	// 		if( %image.item.ammoType $= "ALL" )
	// 		{
	// 			for(%i=0; %i < %player.dataBlock.maxTools; %i++)
	// 			{
	// 				if(isObject(%player.tool[%i]) && %player.toolAmmo[%player.tool[%i].ammotype] < $hl2Weapons::MaxAmmo[%player.tool[%i].ammotype])
	// 				{
	// 					%newAmmo = $hl2Weapons::AddAmmo[%player.tool[%i].ammotype];
	// 					if(%player.toolAmmo[%player.tool[%i].ammotype] + $hl2Weapons::AddAmmo[%player.tool[%i].ammotype] > $hl2Weapons::MaxAmmo[%player.tool[%i].ammotype])
	// 					{
	// 						%newAmmo = ( %player.toolAmmo[%player.tool[%i].ammotype] - $hl2Weapons::MaxAmmo[%player.tool[%i].ammotype] ) * -1;
	// 						%player.toolAmmo[%player.tool[%i].ammotype] = $hl2Weapons::MaxAmmo[%player.tool[%i].ammotype];
	// 					}
	// 					else
	// 					{
	// 						%player.toolAmmo[%player.tool[%i].ammotype] += $hl2Weapons::AddAmmo[%player.tool[%i].ammotype];
	// 					}
	// 					%item = %player.tool[%player.currTool];
	// 					for(%a = 0; %a <= 3; %a++)
	// 					{
	// 						if(%player.line[%a] $= "")
	// 						{
	// 							%player.line[%a] = "<just:right><font:Tahoma:22><color:DBA901>+" @ %newAmmo SPC %player.tool[%i].ammoType;
	// 							break;
	// 						}
	// 					}
	// 					if( %item $= %player.tool[%i] )
	// 					{
	// 						hl2DisplayAmmo(%item.image, %player, %player.currTool);
	// 					}
	// 				}
	// 			}
	// 			for(%a = 0; %a <= 3; %a++)
	// 			{
	// 			 if(%player.line[%a] !$= "")
	// 				{
	// 					%text = %text @ %player.line[%a] @ "<br>";
	// 				}
	// 				else
	// 				{
	// 					break;
	// 				}
	// 			}
	// 			commandToClient(%client, 'centerPrint', %text, 2);
	// 			for(%a = 0; %a <= 4; %a++)
	// 			{
	// 				%player.line[%a] = "";
	// 			}
	// 		}
	// 	}
	// }
	// else
	// {
		parent::addItem(%player, %image, %client);
	// }
}