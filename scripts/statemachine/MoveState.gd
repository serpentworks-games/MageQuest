class_name MoveState extends State

var player

func _ready():
	player = get_parent()
	stateAnim.travel("Run")

func Tick(delta):
	print(delta)

func _physics_process(delta):
	if player.moveDirection:
		#Apply rotation
		player.playerMesh.rotation.y = lerp_angle(player.playerMesh.rotation.y, atan2(player.moveDirection.x, player.moveDirection.z) - player.rotation.y, delta * player.rotationSpeed)
		player.velocity.x = player.moveDirection.x * player.moveSpeed
		player.velocity.z = player.moveDirection.z * player.moveSpeed
	else:
		#move to idle
		player.ChangeState("idle")
		
	if Input.is_action_just_pressed("jump") and player.is_on_floor():
		#move to jump
		player.ChangeState("jump")
	elif Input.is_action_just_pressed("attack") and player.is_on_floor():
		player.ChangeState("attack")
		
