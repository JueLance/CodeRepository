package cn.rocky;

import lombok.extern.slf4j.Slf4j;
import org.springframework.http.*;
import org.springframework.web.client.RestTemplate;
import org.springframework.core.ParameterizedTypeReference;

import java.util.List;

@Slf4j
public class TestService {

    private RestTemplate restTemplate = new RestTemplate();

    public <T, E> ResultData<T> post(String url, E data) throws BizException {
        HttpHeaders headers = new HttpHeaders();
        MediaType type = MediaType.parseMediaType("application/json; charset=UTF-8");
        headers.setContentType(type);

        HttpEntity<E> formEntity = new HttpEntity<E>(data, headers);
        ResultData<T> result = null;

        try {

            ParameterizedTypeReference typeReference = new ParameterizedTypeReference<ResultData<T>>() {
            };

            //Spring框架缺陷，这个地方不能换成泛型！！！！！！！！朱子成
            ResponseEntity<ResultData<T>> restResult = restTemplate.exchange(url, HttpMethod.POST, formEntity, typeReference);

            result = restResult.getBody();

        } catch (Exception e) {
            log.error("request-post Error： url={}，dto={},e={}", url, data, e);
            throw e;
        }

        if (result == null) {
            log.error("request-post Error： url={}，dto={},e={}", url, data, "发送数据失败，未能获取服务器的回应。");
            throw new BizException("发送数据失败，未能获取服务器的回应。", 404);
        }

        return result;
    }

    public ResultData<EmpInfo> post2(String url, Employee data) throws BizException {
        HttpHeaders headers = new HttpHeaders();
        MediaType type = MediaType.parseMediaType("application/json; charset=UTF-8");
        headers.setContentType(type);

        HttpEntity<Employee> formEntity = new HttpEntity<Employee>(data, headers);
        ResultData<EmpInfo> result = null;

        try {

            ParameterizedTypeReference typeReference = new ParameterizedTypeReference<ResultData>() {
            };

            //Spring框架缺陷，这个地方不能换成泛型！！！！！！！！朱子成
            ResponseEntity<ResultData> restResult = restTemplate.exchange(url, HttpMethod.POST, formEntity, typeReference);

            result = restResult.getBody();

        } catch (Exception e) {
            log.error("request-post Error： url={}，dto={},e={}", url, data, e);
            throw e;
        }

        if (result == null) {
            log.error("request-post Error： url={}，dto={},e={}", url, data, "发送数据失败，未能获取服务器的回应。");
            throw new BizException("发送数据失败，未能获取服务器的回应。", 404);
        }

        return result;
    }
}
