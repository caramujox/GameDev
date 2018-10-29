// Fill out your copyright notice in the Description page of Project Settings.

#include "AtorFlutuante.h"


// Sets default values
AAtorFlutuante::AAtorFlutuante()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	TempoExecucao = 0.0f;
	AlturaDelta = 0.0f;
	NovaLoc = FVector(0, 0, 0);

}

// Called when the game starts or when spawned
void AAtorFlutuante::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AAtorFlutuante::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	NovaLoc = this->GetActorLocation();
	UE_LOG(LogTemp, Warning, TEXT("NovaLoc"));
	AlturaDelta = (FMath::Sin(TempoExecucao + DeltaTime) - FMath::Sin(TempoExecucao));
	NovaLoc.Z += AlturaDelta * 20.f;
	TempoExecucao += DeltaTime;
	this->SetActorLocation(NovaLoc);
}

