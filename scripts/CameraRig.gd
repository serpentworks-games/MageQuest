extends Node3D

@export var mouseSensitivity = 5
@export var upperRotLimit = -0.75
@export var lowerRotLimit = 0.25
@export var minZoom = 2
@export var maxZoom = 10

# Called when the node enters the scene tree for the first time.
func _ready():
	Input.mouse_mode = Input.MOUSE_MODE_CAPTURED

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	global_position = $"..".global_position
	
func _input(event):
	if event is InputEventMouseMotion:
		var xRot = clamp(rotation.x - event.relative.y / 1000 * mouseSensitivity, upperRotLimit, lowerRotLimit)
		var yRot = rotation.y - event.relative.x / 1000 * mouseSensitivity
		rotation = Vector3(xRot, yRot, 0)
		
	if event is InputEventMouseButton:
		if event.button_index == 4: #zoom in
			if get_node("SpringArm3D").spring_length < maxZoom:
				get_node("SpringArm3D").spring_length += 0.1
		if event.button_index == 5: #zoom out
			if get_node("SpringArm3D").spring_length > minZoom:
				get_node("SpringArm3D").spring_length -= 0.1
