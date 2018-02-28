#include <stdio.h>
#include <string.h>
#include <iostream>
#include "cn_rocky_NativeMethodTest.h"

using namespace std;

JNIEXPORT jint JNICALL Java_cn_rocky_NativeMethodTest_intMethod(JNIEnv *, jobject, jint num) {
    return num * num;
}

JNIEXPORT jboolean JNICALL Java_cn_rocky_NativeMethodTest_booleanMethod(JNIEnv *, jobject obj, jboolean value) {
    return !value;
}

JNIEXPORT jstring JNICALL Java_cn_rocky_NativeMethodTest_stringMethod(JNIEnv * env, jobject obj, jstring value) {
    const char* str = env->GetStringUTFChars(value, 0);
    char cap[128];
    strcpy(cap, str);
    env->ReleaseStringUTFChars(value, 0);
    return env->NewStringUTF(_strupr(cap));
}

JNIEXPORT jintArray JNICALL Java_cn_rocky_NativeMethodTest_intArrayMethod(JNIEnv * env, jobject obj, jintArray value) {
    int i, sum = 0;
    jsize len = env->GetArrayLength(value);
    jint *body = env->GetIntArrayElements(value, 0);

    for (i = 0; i < len; ++i)
    {
        sum += body[i];
    }
    env->ReleaseIntArrayElements(value, body, 0);
    //TODO:
    return value;
}

JNIEXPORT jobject JNICALL Java_cn_rocky_NativeMethodTest_longMethod(JNIEnv * env, jobject obj, jobject value) {
    return value;
}

JNIEXPORT jobjectArray JNICALL Java_cn_rocky_NativeMethodTest_stringArrayMethod(JNIEnv * env, jobject obj, jobjectArray value) {
    cout << "Java_cn_rocky_NativeMethodTest_stringArrayMethod" << endl;
    int i, sum = 0;
    jsize len = env->GetArrayLength(value);
    jobject obj2 = env->GetObjectArrayElement(value, 0);
    jstring jstr = static_cast<jstring>(obj2);

    cout << "数组元素：len" << len << endl;
    cout << "数组元素：" << jstr << endl;

    return value;
}

JNIEXPORT jobject JNICALL Java_cn_rocky_NativeMethodTest_objectMethod(JNIEnv * env, jobject obj, jobjectArray value) {
    return value;
}

JNIEXPORT jobject JNICALL Java_cn_rocky_NativeMethodTest_objectArrayMethod(JNIEnv * env, jobject obj, jobject value) {
    return value;
}
