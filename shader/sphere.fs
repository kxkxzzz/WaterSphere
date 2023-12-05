#version 330 core

in vec3 Normal;
out vec4 FragColor;

uniform samplerCube skybox;

void main() {
	FragColor = vec4(Normal, 1.0f);
	// FragColor = vec4(0.2f,0.2f,0.2f,1.0f);
}