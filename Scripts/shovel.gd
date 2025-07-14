extends CharacterBody2D

@onready var fire_pos = $"Fire pos"

@export var starting_direction : Vector2 = Vector2(0, 1)
@export var Projectile: PackedScene

func _ready() -> void:
	pass

func _physics_process(delta: float) -> void:
	pass
	
	
#only run when an input goes unhandled and reaches player
func _unhandled_input(event):
	if event.is_action_released("shoot"):
		shoot()

func shoot():
	print("shot")
	var projectile_instance = Projectile.instantiate()
	
	%ProjectileManager.add_child(projectile_instance)
	
	projectile_instance.global_position = fire_pos.global_position
	
	var target = get_global_mouse_position()
	
	var direction_to_mouse = projectile_instance.global_position.direction_to(target).normalized()
	
	projectile_instance.set_direction(direction_to_mouse)
