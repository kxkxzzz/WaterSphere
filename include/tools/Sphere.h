#pragma once

#include <glad/glad.h>

#include <iostream>
#include <vector>
#include <cmath>

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

const float PI = 3.1415926f;

struct Vertex {
	glm::vec3 position;
	glm::vec3 normal;
	glm::vec2 texCoords;
};

class Sphere {
public:
	Sphere(const int precision = 60);
	~Sphere();
	int getNumVertices() const { return vertices.size(); }
	int getNumIndices() const { return indices.size(); }

	std::vector<Vertex> vertices;
	std::vector<GLuint> indices;
};