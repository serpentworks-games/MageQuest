extends CharacterBody3D

#Config Variables
@export var moveSpeed = 5.0
@export var jumpForce = 200
@export var jumpWaitTime = 0.2
@export var rotationSpeed = 10

# Get the gravity from the project settings to be synced with RigidBody nodes.
var gravity = ProjectSettings.get_setting("physics/3d/default_gravity")
var moveDirection

#Refs
var animTree
var playback
var playerMesh
var state
var stateFactory

#Constants
const kJumpEqualizer = 50

func _ready():
	animTree = get_node("AnimationTree")
	playback = animTree.get("parameters/playback")
	playerMesh = get_node("Rig")
	stateFactory = StateFactory.new()
	velocity.y = 0
	ChangeState("idle")

func _physics_process(delta):
	# Add the gravity.
	if not is_on_floor():
		velocity.y -= gravity * delta

	var rightLeftInput = Input.get_action_strength("moveRight") - Input.get_action_strength("moveLeft")
	var forwardBackInput = Input.get_action_strength("moveDown") - Input.get_action_strength("moveUp")
	
	moveDirection = Vector3(rightLeftInput,0, forwardBackInput)
	
	#Handle Rotation
	var hRot = $CamRig.transform.basis.get_euler().y
	moveDirection = moveDirection.rotated(Vector3.UP, hRot).normalized()
	
	move_and_slide()
	
func ChangeState(newStateName):
	#Check for hanging states
	if state != null:
		state.Exit()
		state.queue_free()
	
	#Add new state
	state = stateFactory.GetState(newStateName).new()
	state.Setup("ChangeState", playback, self)
	state.name = newStateName #purely for debugging and dev purposes
	add_child(state)
