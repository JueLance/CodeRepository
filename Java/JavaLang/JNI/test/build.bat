@echo off
javac -encoding utf-8 TestJni.java

javah -jni TestJni

java TestJni