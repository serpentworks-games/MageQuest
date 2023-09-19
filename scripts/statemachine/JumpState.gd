class_name JumpState extends State

var player

func _ready():
	player = get_parent()
	stateAnim.travel("Jump")
	
func _physics_process(delta):
	await get_tree().create_timer(player.jumpWaitTime).timeout
	player.velocity.y += move_toward(player.velocity.y, player.jumpForce, player.jumpForce / player.kJumpEqualizer)
	
	if player.is_on_floor():
		player.ChangeState("idle")
