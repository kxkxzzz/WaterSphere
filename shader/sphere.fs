#version 330 core
out vec4 FragColor;

uniform samplerCube skybox;

void main() {
  FragColor = vec4(0.2f,0.2f,0.2f,1.0f);
}