class_name StateFactory

var states

func _init():
	states = {
		"idle": IdleState,
		"attack": AttackState,
		"move": MoveState,
		"jump": JumpState,
		"death": DeathState
	}
	
func  GetState(stateName):
		if states.has(stateName):
			return states.get(stateName)
