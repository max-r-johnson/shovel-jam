extends Area2D
class_name Projectile_Base

@export var speed = 10


var direction := Vector2.ZERO

func _physics_process(delta: float) -> void:
	#print(direction)
	if direction != Vector2.ZERO:
		var velocity = direction * speed 
		global_position += velocity
	
func set_direction(direction: Vector2):
	self.direction = direction

func _on_body_entered(body: Node2D) -> void:
	queue_free()
