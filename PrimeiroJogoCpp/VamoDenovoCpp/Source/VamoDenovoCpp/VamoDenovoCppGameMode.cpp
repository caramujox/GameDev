// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

#include "VamoDenovoCppGameMode.h"
#include "VamoDenovoCppHUD.h"
#include "VamoDenovoCppCharacter.h"
#include "UObject/ConstructorHelpers.h"

AVamoDenovoCppGameMode::AVamoDenovoCppGameMode()
	: Super()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnClassFinder(TEXT("/Game/FirstPersonCPP/Blueprints/FirstPersonCharacter"));
	DefaultPawnClass = PlayerPawnClassFinder.Class;

	// use our custom HUD class
	HUDClass = AVamoDenovoCppHUD::StaticClass();
}
