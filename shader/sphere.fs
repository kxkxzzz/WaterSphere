#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 Position;

uniform vec3 cameraPos;
uniform samplerCube skybox;

vec3 culReflectLight();
vec3 culRefractLight();

void main()
{             
    vec3 reflectColor = culReflectLight();
    vec3 refractColor = culRefractLight();
    float alpha = 0.8;
    
    FragColor = vec4(mix(reflectColor, refractColor, alpha), alpha);
    //FragColor = vec4(refractColor,1.0f);
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

    vec4 refractedColor = texture(skybox, T);
    return vec3(refractedColor.rgb);
}