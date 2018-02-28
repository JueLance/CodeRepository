#include <stdio.h>
#include "TestJni.h"


JNIEXPORT void JNICALL Java_TestJni_myPrint(JNIEnv * env, jobject obj)
{
    printf("Hello world from cpp!/n");
}
