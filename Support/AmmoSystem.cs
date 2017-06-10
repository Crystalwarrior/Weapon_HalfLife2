//########## Ammo System
if($JackMods::Server::hl2AmmoSystemVersion > 1)
{
	return;
}

$JackMods::Server::hl2AmmoSystemVersion = 1;
function hl2AmmoCheck(%this,%obj,%slot)
{
	 if(!$hl2Weapons::ammoSystem)
	 {
		return;
	 }

	 if(%obj.toolMag[%obj.currTool] $= "")
	 {
			%obj.toolMag[%obj.currTool] = %this.item.maxmag;
	 }

	 if(%obj.toolAltMag[%this.item.altammotype] $= "" && %this.item.altmaxmag !$= "")
	 {
			%obj.toolAltMag[%this.item.altammotype] = 0;//%this.item.altmaxmag;
	 }

	 if(%obj.toolAmmo[%this.item.ammotype] $= "")
	 {
			%obj.toolAmmo[%this.item.ammotype] = $hl2Weapons::AddAmmo[%this.item.ammotype];
	 }

	 if(%obj.toolMag[%obj.currTool] < 1)
	 {
			%obj.toolMag[%obj.currTool] = 0;
			%obj.setImageAmmo(0,0);
			if(%obj.toolAmmo[%this.item.ammotype] < 1)
			{
				 %obj.toolMag[%obj.currTool] = %obj.toolAmmo[%this.item.ammotype] = 0;
			}
	 }

	 if(%obj.toolMag[%obj.currTool] > %this.item.maxmag)
	 {
			%obj.toolMag[%obj.currTool] = %this.item.maxmag;
	 }
}

function hl2AmmoOnReload(%this,%obj,%slot)
{
	if(!$hl2Weapons::ammoSystem)
	{
	 return;
	}
	if($hl2Weapons::Ammo)
	{
		if(%this.item.nochamber)
		{
			%a = %this.item.maxmag - %obj.toolMag[%obj.currTool];
			if(%a > %obj.toolAmmo[%this.item.ammotype])
				%a = %obj.toolAmmo[%this.item.ammotype];
			%obj.toolMag[%obj.currTool] += %a;
			%obj.toolAmmo[%this.item.ammotype] -= %a;
			%obj.setImageAmmo(0,1);
		}
		else
		{
			if(%obj.toolMag[%obj.currTool] > 0)
			{
				%a = (%this.item.maxmag) - %obj.toolMag[%obj.currTool];
				if(%a > %obj.toolAmmo[%this.item.ammotype])
					%a = %obj.toolAmmo[%this.item.ammotype];
				%obj.toolMag[%obj.currTool] += %a;
				%obj.toolAmmo[%this.item.ammotype] -= %a;
				%obj.setImageAmmo(0,1);
			}
			else
			{
				%a = %this.item.maxmag - %obj.toolMag[%obj.currTool];
				if(%a > %obj.toolAmmo[%this.item.ammotype])
					%a = %obj.toolAmmo[%this.item.ammotype];
				%obj.toolMag[%obj.currTool] += %a;
				%obj.toolAmmo[%this.item.ammotype] -= %a;
				%obj.setImageAmmo(0,0);
			}
		}
	}
	else
	{
		if(%this.item.nochamber)
		{
			%obj.toolMag[%obj.currTool] = %this.item.maxmag;
			%obj.setImageAmmo(0,1);
		}
		else
		{
			if(%obj.toolMag[%obj.currTool] > 0)
			{
				%obj.toolMag[%obj.currTool] = %this.item.maxmag;
				%obj.setImageAmmo(0,1);
			}
			else
			{
				%obj.toolMag[%obj.currTool] = %this.item.maxmag;
				%obj.setImageAmmo(0,0);
			}
		}
	}
}

function hl2AmmoOnReloadSingle(%this,%obj,%slot)
{
	if(!$hl2Weapons::ammoSystem)
	{
	 return;
	}
	if($hl2Weapons::Ammo)
	{
		%obj.toolMag[%obj.currTool]++;
		%obj.toolAmmo[%this.item.ammotype]--;
		if(%obj.toolAmmo[%this.item.ammotype] < 1) {
			%obj.setImageAmmo(0,1);
			return; }
		else
			%obj.setImageAmmo(0,0);
		if(%obj.toolMag[%obj.currTool] < %this.item.maxmag)
			%obj.setImageAmmo(0,0);
		else
			%obj.setImageAmmo(0,1);
	}
	else
	{
		%obj.toolMag[%obj.currTool]++;
		if(%obj.toolMag[%obj.currTool] < %this.item.maxmag)
			%obj.setImageAmmo(0,0);
		else
			%obj.setImageAmmo(0,1);
	}
}

function hl2DisplayAmmo(%this, %obj, %slot, %delay) {
	if (!$hl2Weapons::ShowAmmo || !isObject(%obj.client)) {
		return;
	}

	if (%delay == -1) {
		clearBottomPrint(%obj.client);
		return;
	}

	%altMag = %obj.toolAltMag[%this.item.altAmmoType];

	if (%altMag !$= "") {
		%altAmmoText = "    " SPC %altmag;
	}

	if ($hl2Weapons::Ammo == 0) {
		%str = %obj.toolMag[%obj.currTool] @ "/" @ %this.item.maxMag;
	}
	else {
		%str = %obj.toolMag[%obj.currTool] @ "/" @ %obj.toolAmmo[%this.item.ammoType];
	}

	%ammocol = "<color:DBA901>";
	%str = %str SPC "<font:tahoma:20>AMMO<font:impact:24>" @ ( %altAmmoText !$= "" ? %altAmmoText SPC "<font:impact:20>ALT" : "" );
	%obj.client.bottomPrint(%ammocol @ "<font:impact:24><just:right>" @ %str SPC "\n", %delay, 1);
}

package hl2AmmoSystem
{
	function gameConnection::onDeath( %client, %source, %killer, %type, %location )
	{
		hl2DisplayAmmo(0, %client.player, %slot, -1);
		parent::onDeath( %client, %source, %killer, %type, %location );
	}

	function Player::pickUp(%this,%item)
	{
		%data = %item.dataBlock;

		if(%item.mag !$= "")
		{
			%mag = %item.mag;
		}
		%parent = parent::pickUp(%this,%item);
		if(!%data.reload || !$hl2Weapons::ammoSystem)
		{
			return %parent;
		}

		%slot = -1;
		for(%i=0;%i<%this.dataBlock.maxTools;%i++)
		{
			if(isObject(%this.tool[%i]) && %this.tool[%i].getID() == %data.getID())
			{
				%slot = %i;
				break;
			}
		}
		if(%slot == -1)
		{
			return;
		}
		if(%mag !$= "")
		{
			%this.toolMag[%slot] = %mag;
		}
		else
		{
			%this.toolmag[%slot] = %data.maxmag;
		}
	}

	function serverCmdDropTool(%client,%slot)
	{
		if(isObject(%client.player))
		{
			%item = %client.player.tool[%client.player.currTool];
			$hl2weaponMag = %client.player.toolMag[%client.player.currTool];
			%client.player.toolMag[%client.player.currTool] = "";
		}
		parent::serverCmdDropTool(%client,%slot);
		%client.player.unMountImage(0);
	}

	function ItemData::onAdd(%this,%obj)
	{
		parent::onAdd(%this,%obj);
		if($hl2weaponMag !$= "") { %obj.mag = $hl2weaponMag; $hl2weaponMag = ""; }
	}

	function serverCmdLight(%client)
	{
		if(isObject(%client.player)) {
			%player = %client.player;
			%image = %player.getMountedImage(0);
			if(%image.item.reload && $hl2Weapons::ammoSystem)
			{
				if(%player.getImageState(0) $= "Ready" || %player.getImageState(0) $= "Empty")
				{
					if(%player.toolMag[%player.currTool] < %image.item.maxmag)
					{
						if($hl2Weapons::Ammo && %player.toolAmmo[%image.item.ammotype] < 1) { parent::serverCmdLight(%client); return; }
						%player.setImageAmmo(0,0);
						%player.Schedule(50,setImageAmmo,0,1);
					}
					else
						parent::serverCmdLight(%client);
				}
				return;
			}
		}
		parent::serverCmdLight(%client);
	}

	function Armor::onCollision(%this,%obj,%col,%a,%b,%c,%d,%e,%f)
	{
		if(%col.dataBlock.reload $= "" && %col.dataBlock.ammoBox $= "" || !$hl2Weapons::Ammo || !$hl2Weapons::ammoSystem)
		{
			if(%col.dataBlock.ammoBox)
			{
				return;
			}
			parent::onCollision(%this,%obj,%col,%a,%b,%c,%d,%e,%f);
			return;
		}

		if(%col.dataBlock.ammoBox && ( %col.dataBlock.ammoType !$= "" || %col.dataBlock.altAmmoType !$= "" ) && %col.canPickup && %obj.getDamagePercent() < 1 && minigameCanUse(%obj.client,%col))
		{
			if( %col.dataBlock.ammoType $= "ALL" )
			{
				for(%i=0; %i < %obj.dataBlock.maxTools; %i++)
				{
					if(isObject(%obj.tool[%i]) && %obj.toolAmmo[%obj.tool[%i].ammotype] < $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype])
					{
						%newAmmo = $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype];
						if(%obj.toolAmmo[%obj.tool[%i].ammotype] + $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype] > $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype])
						{
							%newAmmo = ( %obj.toolAmmo[%obj.tool[%i].ammotype] - $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype] ) * -1;
							%obj.toolAmmo[%obj.tool[%i].ammotype] = $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype];
						}
						else
						{
							%obj.toolAmmo[%obj.tool[%i].ammotype] += $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype];
						}
						%item = %obj.tool[%obj.currTool];
						for(%a = 0; %a <= 3; %a++)
						{
							if(%obj.line[%a] $= "")
							{
								%obj.line[%a] = "<just:right><font:Tahoma:22><color:DBA901>+" @ %newAmmo SPC %obj.tool[%i].ammoType;
								break;
							}
						}
						if( %item $= %obj.tool[%i] )
						{
							hl2DisplayAmmo(%item.image, %obj, %obj.currTool);
						}
					}
				}
				for(%a = 0; %a <= 3; %a++)
				{
				 if(%obj.line[%a] !$= "")
					{
						%text = %text @ %obj.line[%a] @ "<br>";
					}
					else
					{
						break;
					}
				}
				commandToClient(%obj.client, 'centerPrint', %text, 2);
				for(%a = 0; %a <= 4; %a++)
				{
				 %obj.line[%a] = "";
				}
			}
			else
			{
				for(%i=0; %i < %obj.dataBlock.maxTools; %i++)
				{
					if(isObject(%obj.tool[%i]) && %obj.tool[%i].ammotype $= %col.dataBlock.ammoType && %obj.toolAmmo[%obj.tool[%i].ammotype] < $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype])
					{
						%obj.toolAmmo[%obj.tool[%i].ammotype] += $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype];
						%newAmmo = $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype];
						if(%obj.toolAmmo[%obj.tool[%i].ammotype] + $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype] > $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype])
						{
							%newAmmo = ( %obj.toolAmmo[%obj.tool[%i].ammotype] - $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype] ) * -1;
							%obj.toolAmmo[%obj.tool[%i].ammotype] = $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype];
						}
						else
						{
							%obj.toolAmmo[%obj.tool[%i].ammotype] += $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype];
						}
						%item = %obj.tool[%obj.currTool];
						if( %item $= %obj.tool[%i] )
						{
							hl2DisplayAmmo(%item.image, %obj, %obj.currTool);
						}
						
						commandToClient(%obj.client, 'centerPrint', "<just:right><font:Tahoma:22><color:DBA901>+" @ %newammo SPC %obj.tool[%i].ammoType, 2);
					}
					else
					{
						if(isObject(%obj.tool[%i]) && %obj.tool[%i].altammotype $= %col.dataBlock.altammotype && %obj.toolAltMag[%obj.tool[%i].altammotype] < %obj.tool[%i].altmaxmag)
						{    
							%newAmmo = %col.dataBlock.altAmmoAdd;
							if(%obj.toolAltMag[%obj.tool[%i].altammotype] + %col.dataBlock.altAmmoAdd > %obj.tool[%i].altmaxmag)
							{
								%newAmmo = (%obj.toolAltMag[%obj.tool[%i].altammotype] - %obj.tool[%i].altmaxmag) * -1;
								%obj.toolAltMag[%obj.tool[%i].altammotype] = %obj.tool[%i].altmaxmag;
							}
							else
							{
								%obj.toolAltMag[%obj.tool[%i].altammotype] += %col.dataBlock.altAmmoAdd;
							}
							%item = %obj.tool[%obj.currTool];
							if( %item $= %obj.tool[%i] )
							{
								hl2DisplayAmmo(%item.image, %obj, %obj.currTool);
							}
							if( %newAmmo > 0 )
							{
								commandToClient(%obj.client, 'centerPrint', "<just:right><font:Tahoma:22><color:DBA901>+" @ %newammo SPC %obj.tool[%i].altammotype, 2);
							}
						}
					}
				}
			}
			serverPlay3D(hl2PickUpSound,%obj.getHackPosition());

			//parent::onCollision(%this,%obj,%col,%a,%b,%c,%d,%e,%f);

			if(isObject(%col.spawnBrick))
			{
				%col.fadeOut();
				%col.schedule(%col.spawnBrick.itemRespawnTime,fadein);
			}
			else
			{
				%col.schedule(10,delete);
			}
			return;
		}

		for(%i=0; %i < %obj.dataBlock.maxTools; %i++)
		{
			if(isObject(%obj.tool[%i]) && %obj.toolAmmo[%obj.tool[%i].ammotype] < $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype])
			{
				if(%obj.tool[%i].getName() $= %col.dataBlock && %col.canPickup && %obj.getDamagePercent() < 1 && minigameCanUse(%obj.client,%col))
				{
					if(isObject(%col.spawnBrick))
					{
						%newAmmo = $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype];
						if(%obj.toolAmmo[%obj.tool[%i].ammotype] + $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype] > $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype])
						{
							%newAmmo = ( %obj.toolAmmo[%obj.tool[%i].ammotype] - $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype] ) * -1;
							%obj.toolAmmo[%obj.tool[%i].ammotype] = $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype];
						}
						else
						{
							%obj.toolAmmo[%obj.tool[%i].ammotype] += $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype];
						}

						serverPlay3D(hl2PickUpSound,%obj.getHackPosition());
						commandToClient(%obj.client, 'centerPrint', "<just:right><font:Tahoma:22><color:DBA901>+" @ %newAmmo SPC %obj.tool[%i].ammoType, 2);

						%item = %obj.tool[%obj.currTool];
						if( %item $= %obj.tool[%i] )
						{
							hl2DisplayAmmo(%item.image, %obj, %obj.currTool);
						}

						%col.fadeOut();
						%col.schedule(%col.spawnBrick.itemRespawnTime,fadein);
						break;
					}
					else
					{
						%mag = %col.mag;
						if(%mag !$= 0)
						{
							if(%mag $= "")
							{
								%mag = $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype];
							}

							
							%newAmmo = %mag;
							if(%obj.toolAmmo[%obj.tool[%i].ammotype] + $hl2Weapons::AddAmmo[%obj.tool[%i].ammotype] > $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype])
							{
								%newAmmo = ( %obj.toolAmmo[%obj.tool[%i].ammotype] - $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype] ) * -1;
								%obj.toolAmmo[%obj.tool[%i].ammotype] = $hl2Weapons::MaxAmmo[%obj.tool[%i].ammotype];
							}
							else
							{
								%obj.toolAmmo[%obj.tool[%i].ammotype] += %mag;
							}
							%col.mag = %mag - %newAmmo;
							serverPlay3D(hl2PickUpSound,%obj.getHackPosition());

							if(%newAmmo > 0)
							{
								commandToClient(%obj.client, 'centerPrint', "<just:right><font:Tahoma:22><color:DBA901>+" @ %newAmmo SPC %obj.tool[%i].ammoType, 2);
							}
							break;
							respawn(%col);
						}
					}
					%item = %obj.tool[%obj.currTool];
					if( %item $= %obj.tool[%i] )
					{
						hl2DisplayAmmo(%item.image, %obj, %obj.currTool);
					}
				}
			}
		}
		parent::onCollision(%this,%obj,%col,%a,%b,%c,%d,%e,%f);
	}
};
activatePackage(hl2AmmoSystem);