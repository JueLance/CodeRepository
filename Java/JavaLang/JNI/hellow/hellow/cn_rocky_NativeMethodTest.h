/* DO NOT EDIT THIS FILE - it is machine generated */
#include <jni.h>
/* Header for class cn_rocky_NativeMethodTest */

#ifndef _Included_cn_rocky_NativeMethodTest
#define _Included_cn_rocky_NativeMethodTest
#ifdef __cplusplus
extern "C" {
#endif
/*
 * Class:     cn_rocky_NativeMethodTest
 * Method:    intMethod
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_cn_rocky_NativeMethodTest_intMethod
  (JNIEnv *, jobject, jint);

/*
 * Class:     cn_rocky_NativeMethodTest
 * Method:    booleanMethod
 * Signature: (Z)Z
 */
JNIEXPORT jboolean JNICALL Java_cn_rocky_NativeMethodTest_booleanMethod
  (JNIEnv *, jobject, jboolean);

/*
 * Class:     cn_rocky_NativeMethodTest
 * Method:    stringMethod
 * Signature: (Ljava/lang/String;)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_cn_rocky_NativeMethodTest_stringMethod
  (JNIEnv *, jobject, jstring);

/*
 * Class:     cn_rocky_NativeMethodTest
 * Method:    intArrayMethod
 * Signature: ([I)[I
 */
JNIEXPORT jintArray JNICALL Java_cn_rocky_NativeMethodTest_intArrayMethod
  (JNIEnv *, jobject, jintArray);

/*
 * Class:     cn_rocky_NativeMethodTest
 * Method:    longMethod
 * Signature: (Ljava/lang/Long;)Ljava/lang/Long;
 */
JNIEXPORT jobject JNICALL Java_cn_rocky_NativeMethodTest_longMethod
  (JNIEnv *, jobject, jobject);

/*
 * Class:     cn_rocky_NativeMethodTest
 * Method:    stringArrayMethod
 * Signature: ([Ljava/lang/String;)[Ljava/lang/String;
 */
JNIEXPORT jobjectArray JNICALL Java_cn_rocky_NativeMethodTest_stringArrayMethod
  (JNIEnv *, jobject, jobjectArray);

/*
 * Class:     cn_rocky_NativeMethodTest
 * Method:    objectMethod
 * Signature: ([Lcn/rocky/People;)Lcn/rocky/People;
 */
JNIEXPORT jobject JNICALL Java_cn_rocky_NativeMethodTest_objectMethod
  (JNIEnv *, jobject, jobjectArray);

/*
 * Class:     cn_rocky_NativeMethodTest
 * Method:    objectArrayMethod
 * Signature: (Ljava/util/List;)Ljava/util/List;
 */
JNIEXPORT jobject JNICALL Java_cn_rocky_NativeMethodTest_objectArrayMethod
  (JNIEnv *, jobject, jobject);

#ifdef __cplusplus
}
#endif
#endif