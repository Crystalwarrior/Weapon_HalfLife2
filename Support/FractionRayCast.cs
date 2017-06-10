function fractionRayCast(%a, %b, %mask, %ignore, %step) {
	if (%step $= "") {
		%step = 20;
	}

	if (%step <= 0) {
		return 0;
	}

	if (%step < 2) {
		error("ERROR: Too low values of `%step` would be very slow.");
		return 0;
	}

	%distance = vectorDist(%a, %b);
	echo(%distance);
	echo(%b);
	%vector = vectorSub(%b, %a);

	if (%distance <= %step) {
		return containerRayCast(%a, %b, %mask, %ignore);
	}

	for (%p = 0; %p <= %distance; %d += %step) {
		%n = %p + %step;

		if (%n > %distance) {
			%n = %distance;
		}

		%ray = containerRayCast(
			vectorAdd(%a, vectorScale(%vector, %p)),
			vectorAdd(%a, vectorScale(%vector, %n)),
			%mask, %ignore
		);

		if (%ray !$= 0) {
			return %ray;
		}
	}

	return 0;
}

function Player::shootRay(%this, %slot, %range, %offset, %mask, %step) {
	if (%mask $= "") {
		%mask = $TypeMasks::FxBrickObjectType |
			$TypeMasks::TerrainObjectType |
			$TypeMasks::VehicleObjectType |
			$TypeMasks::PlayerObjectType;
	}

	%point = %this.getMuzzlePoint(%slot);
	%vector = vectorAdd(%this.getMuzzleVector(%slot), %offset);

	%eye = %this.getEyePoint();
	%test = containerRayCast(%eye, %point, %mask, %this);

	if (%test $= 0) {
		%a = %point;
		%b = vectorAdd(%point, vectorScale(%vector, %range));
	}
	else {
		%a = %eye;
		%b = %point;
	}

	return fractionRayCast(%a, %b, %mask, %this, %step);
}