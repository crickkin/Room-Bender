shader_type canvas_item;
uniform vec4 outcolor : hint_color;
uniform vec4 gridcolor : hint_color;
void fragment(){
	vec4 col = texture(TEXTURE, UV);
	vec2 screensize = (vec2(1.)/SCREEN_PIXEL_SIZE.xy);
	vec2 screen = SCREEN_UV * screensize;
	vec2 tilesize = (vec2(1.)/TEXTURE_PIXEL_SIZE.xy);
	vec2 tile = UV * tilesize;	
	col.rgba *=  
	(screen.x < (screensize.x*.5 - tilesize.x * 1.5 * 4.)||
	screen.x > (screensize.x*.5 + tilesize.x * 1.5 * 4.)||
	screen.y < (screensize.y*.5 - tilesize.y * 1.5 * 4.)||
	screen.y > (screensize.y*.5 + tilesize.y * 1.5 * 4.))
	? outcolor :vec4(1.);
	col.rgba *= gridcolor;
	COLOR = col;
}