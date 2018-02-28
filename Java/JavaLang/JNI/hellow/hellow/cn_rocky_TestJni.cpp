#include <stdio.h>
#include "cn_rocky_TestJni.h"

JNIEXPORT void JNICALL Java_cn_rocky_TestJni_myPrint(JNIEnv *, jobject)
{
    printf("Hello world from cpp!/n");
}
