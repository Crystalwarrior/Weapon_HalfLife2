$Pref::Server::DecalLimit = 100;
$Pref::Server::DecalTimeout = 20000;

function spawnDecal(%dataBlock, %position, %vector, %size, %effect) {
	if (!isObject(MissionCleanup)) {
		error("ERROR: MissionCleanup not created.");
		return -1;
	}

	if (!isObject(%dataBlock) || %dataBlock.getClassName() !$= StaticShapeData) {
		return;
	}

	if (%size $= "") {
		%size = %dataBlock.decalSize;
	}

	if (%size $= "") {
		%size = 1;
	}

	%obj = new StaticShape() {
		dataBlock = %dataBlock;
	};

	if (!isObject(%obj)) {
		error("ERROR: Unable to create object.");
		return -1;
	}

	if (!isObject(DecalGroup)) {
		MissionCleanup.add(new SimSet(DecalGroup));
	}

	DecalGroup.add(%obj);

	while (DecalGroup.getCount() >= $Pref::Server::DecalLimit) {
		DecalGroup.getObject(0).delete();
	}

	if (!isObject(%obj)) {
		return -1;
	}

	%obj.setTransform(%position SPC vectorToAxis(%vector));
	%obj.setScale(%size SPC %size SPC %size);

	if (%dataBlock.doColorShift) {
		%obj.setNodeColor("ALL", %dataBlock.colorShiftColor);
	}

	if ($Pref::Server::DecalTimeout !$= "" && !%effect) {
		%obj.schedule($Pref::Server::DecalTimeout - 1000, fadeOut);
		%obj.schedule($Pref::Server::DecalTimeout, delete);
	}
	return %obj;
}

function spawnDecalFromRayCast(%dataBlock, %rayCast, %size) {
	if (%rayCast $= 0) {
		return -1;
	}

	return spawnDecal(%dataBlock, getWords(%rayCast, 1, 3), getWords(%rayCast, 4, 6), %size);
}

function sprayDecalWithRayCast(%dataBlock, %a, %b, %mask, %avoid, %size) {
	return spawnDecalFromRayCast(%dataBlock, containerRayCast(%a, %b, %mask, %avoid), %size);
}

function vectorToAxis(%vector) {
	%y = mRadToDeg(mACos(getWord(%vector, 2) / vectorLen(%vector))) % 360;
	%z = mRadToDeg(mATan(getWord(%vector, 1), getWord(%vector, 0)));

	%euler = vectorScale(0 SPC %y SPC %z, $pi / 180);
	return getWords(matrixCreateFromEuler(%euler), 3, 6);
}