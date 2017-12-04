package cn.rocky;

public class BizException extends Exception {
    public BizException(String msg, Integer code) {
        super(msg);
    }
}