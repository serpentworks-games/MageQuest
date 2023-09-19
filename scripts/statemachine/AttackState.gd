class_name AttackState extends State

var player

const kXFadeDuration = 0.25 #set slightly longer than the xfade duration

func _ready():
	player = get_parent()
	stateAnim.travel("Attack")
	player.velocity.x = 0
	player.velocity.z = 0
	
func _physics_process(delta):
	if stateAnim.get_current_play_position() >= stateAnim.get_current_length() - kXFadeDuration:
		player.ChangeState("idle")
