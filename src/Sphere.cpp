#include "Sphere.h"

Sphere::Sphere(const int precision) {

	// vertices
	// γ��
	for (int row = 0; row <= precision; row++) {
		float alpha = row * PI / precision;
		float ypos = cos(alpha);
		// ����
		for (int col = 0; col <= precision; col++) {
			float beta = col * 2 * PI / precision;
			float xpos = sin(alpha) * sin(beta);
			float zpos = sin(alpha) * cos(beta);
			glm::vec3 pos(xpos, ypos, zpos);
			glm::vec3 normal(xpos, ypos, zpos);
			glm::vec2 texCoords((float) row / precision, (float) col / precision);
			Vertex vertex(pos, normal, texCoords);
			vertices.push_back(vertex);
		}
	}

	// indices
	// γ��
	for (int row = 0; row < precision; row++) {
		// ����
		for (int col = 0; col < precision; col++) {
			GLuint p1 = row * (precision + 1) + col;	// ����
			GLuint p2 = (row + 1) * (precision + 1) + col; // ����
			GLuint p3 = (row + 1) * (precision + 1) + col + 1; // ����
			GLuint p4 = row * (precision + 1) + col + 1; // ����

			indices.push_back(p1);
			indices.push_back(p2);
			indices.push_back(p3);

			indices.push_back(p1);
			indices.push_back(p3);
			indices.push_back(p4);
		}
	}
}

Sphere::~Sphere() {}

