package cn.rocky;

import lombok.Data;

@Data
public class ResultData<T> {
    private T result;
    private Integer code;
    private String message;
}
