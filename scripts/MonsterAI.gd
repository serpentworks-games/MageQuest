extends CharacterBody3D

#public
@export var moveSpeed = 2.0
@export var rotationSpeed = 20
@export var monsterHealth = 10
@export var idleAnimName = ""
@export var moveAnimName = ""
@export var attackAnimName = ""
@export var deathAnimName = ""

#state
var canChasePlayer = false
var canAttackPlayer = false
var direction

#refs
var mesh
var anim
var player

#consts
var gravity = ProjectSettings.get_setting("physics/3d/default_gravity")

func _ready():
	mesh = get_node("Slime")
	player = get_node("../../Characters/Player")
	anim = get_node("Slime/AnimationPlayer")


func _physics_process(delta):
	direction = Vector3.ZERO
	if not is_on_floor():
		velocity.y -= gravity * delta
	
	if player:
		direction = (player.position - position).normalized()
		
	if canChasePlayer:
		if direction:
			mesh.rotation.y = lerp_angle(mesh.rotation.y, atan2(direction.x, direction.z) - mesh.rotation.y, delta * rotationSpeed)
			anim.play(moveAnimName)
			velocity.x = direction.x * moveSpeed
			velocity.z = direction.z * moveSpeed
	elif canAttackPlayer && direction:
		if direction:
			mesh.rotation.y = lerp_angle(mesh.rotation.y, atan2(direction.x, direction.z) - mesh.rotation.y, delta * rotationSpeed)
			anim.play(attackAnimName)
			velocity.x = 0
			velocity.z = 0
	else:
		anim.play(idleAnimName)
		velocity.x = 0
		velocity.z = 0
		
	move_and_slide()


func OnAttackZoneEntered(body):
	if "Player" in body.name:
		canAttackPlayer = true
		canChasePlayer = false

func OnAttackZoneExited(body):
	if "Player" in body.name:
		canAttackPlayer = false
		canChasePlayer = true

func OnChaseZoneEntered(body):
	if "Player" in body.name:
		canChasePlayer = true

func OnChaseZoneExited(body):
	if "Player" in body.name:
		canChasePlayer = false
