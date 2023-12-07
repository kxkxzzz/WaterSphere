#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 Position;

uniform vec3 cameraPos;
uniform samplerCube skybox;

vec3 culReflectLight();
vec3 culRefractLight();
float schlick(float cosine, float refractiveIndex); 

void main()
{             
    vec3 reflectColor = culReflectLight();
    vec3 refractColor = culRefractLight();

    vec3 N = normalize(Normal);
    vec3 I = normalize(Position - cameraPos);

    float reflectance = schlick(dot(N, -I), 1.33);
    FragColor = vec4(mix(refractColor, reflectColor, reflectance * 0.8), 1.0);
}

vec3 culReflectLight()
{
    vec3 I = normalize(Position - cameraPos);
    vec3 R = reflect(I, normalize(Normal));
    return vec3(texture(skybox, R).rgb);
}

vec3 culRefractLight()
{
    vec3 N = normalize(Normal);
    vec3 I = normalize(Position - cameraPos);
    vec3 T = refract(I, N, 0.66);
    // vec3 T = refract(I, N, 0.8);
    // vec3 T = refract(I, N, 0.95);

    vec4 refractedColor = texture(skybox, T);
    return vec3(refractedColor.rgb);
}

float schlick(float cosine, float refractiveIndex){
    float r0 = pow((1.0 - refractiveIndex) / (1.0 + refractiveIndex), 2.0);
    return r0 + (1.0 - r0) * pow(1.0 - cosine, 5.0);
}