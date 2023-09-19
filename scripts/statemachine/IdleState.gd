class_name IdleState extends State

var player

func _ready():
	player = get_parent()
	stateAnim.travel("Idle")
	
func _physics_process(delta):
	if Input.is_action_pressed("moveUp") or Input.is_action_pressed("moveDown") or Input.is_action_pressed("moveLeft") or Input.is_action_pressed("moveRight"):
		player.ChangeState("move")
	if Input.is_action_just_pressed("jump") and player.is_on_floor():
		player.ChangeState("jump")
	elif Input.is_action_just_pressed("attack") and player.is_on_floor():
		player.ChangeState("attack")
		
	player.velocity.x = move_toward(player.velocity.x, 0, player.moveSpeed)
	player.velocity.z = move_toward(player.velocity.z, 0, player.moveSpeed)
	
