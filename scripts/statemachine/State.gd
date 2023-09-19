class_name State extends Node

var changeState
var stateAnim
var persistantState

#Sets up the state
func Setup(changeState, stateAnim, persistantState):
	self.changeState = changeState
	self.stateAnim = stateAnim
	self.persistantState = persistantState
	
func Enter():
	print("Entering State!")
	
func Tick(delta):
	print("Ticking State!")
	
func Exit():
	print("Exiting State!")
