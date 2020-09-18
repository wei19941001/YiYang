// 获取url中的参数
function getUrlParam(name) {
  var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
  var r = window.location.search.substr(1).match(reg);  //匹配目标参数
  if (r != null) return unescape(r[2]); // eslint-disable-line
  return null; //返回参数值
}

// 添加/修改url中参数的值
function setUrlParam(name, val) {
  var thisURL = document.location.href;
  // 如果url中包含这个参数，则修改
  if (thisURL.indexOf(name + '=') > 0) {
    var v = getUrlParam(name);
    if (v != null) {  // eslint-disable-line
      thisURL = thisURL.replace(name + '=' + v, name + '=' + val);
    }
    else {
      thisURL = thisURL.replace(name + '=', name + '=' + val);
    }
  }
  // 不包含这个参数，则添加
  else {
    if (thisURL.indexOf("?") > 0) {
      thisURL = thisURL + "&" + name + "=" + val;
    }
    else {
      thisURL = thisURL + "?" + name + "=" + val;
    }
  }
  window.location.href = thisURL;
}

// 日期转字符
Date.prototype.toFomatorString = function (formator) {
  if (formator.indexOf("yyyy") > -1) {
    formator = formator.replace("yyyy", this.getFullYear());
  }
  if (formator.indexOf("MM") > -1) {
    formator = formator.replace("MM", this.getMonth() + 1);
  }
  if (formator.indexOf("dd") > -1) {
    formator = formator.replace("dd", this.getDate());
  }
  if (formator.indexOf("HH") > -1) {
    var hour = this.getHours();
    formator = formator.replace("HH", hour < 10 ? '0' + hour : hour);
  }
  if (formator.indexOf("mm") > -1) {
    var minutes = this.getMinutes();
    formator = formator.replace("mm", minutes < 10 ? '0' + minutes : minutes);
  }
  if (formator.indexOf("ss") > -1) {
    var seconds = this.getSeconds();
    formator = formator.replace("ss", seconds < 10 ? '0' + seconds : seconds);
  }
  if (formator.indexOf("ffff") > -1) {
    var milliseconds = this.getMilliseconds();
    formator = formator.replace("ffff", milliseconds < 100 ? milliseconds < 10 ? '00' + milliseconds : '0' + milliseconds : milliseconds);
  }
  return formator;
};
// 字符转日期
String.prototype.toDate = function () {
  var temp = this.toString();
  temp = temp.replace(/-/g, "/");
  var date = new Date(Date.parse(temp));
  return date;
};
// Json字符转日期
String.prototype.jsonToDateString = function () {
  var temp = this.toString();
  var d = eval('new ' + temp.substr(1, temp.length - 2));
  var ar_date = [d.getFullYear(), d.getMonth() + 1, d.getDate()];
  for (var i = 0; i < ar_date.length; i++) {
    ar_date[i] = dFormat(ar_date[i]);
  }
  var ar_time = [d.getHours(), d.getMinutes()];
  for (var j = 0; j < ar_time.length; j++) {
    ar_time[j] = dFormat(ar_time[j]);
  }
  return ar_date.join('-') + ' ' + ar_time.join(':');

};
function dFormat(i) {
  return i < 10 ? "0" + i.toString() : i;
}
// 数组扩展
Array.prototype.indexOf = function (val) {
  for (var i = 0; i < this.length; i++) {
    if (this[i] == val) // eslint-disable-line
      return i;
  }
  return -1;
};
Array.prototype.remove = function (val) {
  var index = this.indexOf(val);
  if (index > -1) {
    this.splice(index, 1);
  }
};
// 去重
Array.prototype.unique = function () {
  this.sort();
  var array = [this[0]];
  for (var i = 1; i < this.length; i++) {
    if (this[i] != array[array.length - 1]) { // eslint-disable-line
      array.push(this[i]);
    }
  }
  return array;
};
// 去除空项
Array.prototype.trim = function () {
  var array = this;
  for (var i = 0; i < array.length; i++) {
    if (array[i] == "" || typeof (array[i]) == "undefined") { // eslint-disable-line
      array.splice(i, 1);
      i = i - 1;
    }
  }
  return array;
};
// 初始化结束
$$(function () {
  // 异步提交表单
  $$.fn.ajaxSubmitForm = function (callback, errorback) {
    var $$formEle = $$(this);
    // 提交
    $$.ajax({
      async: true,
      cache: false,
      type: $$formEle.attr('method'),
      url: $$formEle.attr('action'),
      data: $$formEle.serialize(),
      dataType: 'json',
      success: function (res) {
        if (res.StatusCode == 1) {  // eslint-disable-line
          try {
            if (typeof (eval(callback)) == "function")  // eslint-disable-line
              callback(res.Result);
            else
              window.location.reload();
          }
          catch (e) {
            console.log(e);
          }
        }
        else {
          try {
            alert(res.Message);
            if (typeof (eval(errorback)) == "function") // eslint-disable-line
              errorback();
          }
          catch (e) {
            console.log(e);
          }
        }
      },
      error: function () {
        alert('请求失败！');
      }
    });
  };
  // Post请求扩展
  $$.jsonResultPostHandle = function (url, data, callback, errorback) {
    $$.ajax({
      async: true,
      cache: false,
      dataType: 'json',
      url: url,
      data: data,
      type: 'POST',
      success: function (res) {
        if (res.StatusCode == 1) {  // eslint-disable-line
          try {
            if (typeof (eval(callback)) == "function")  // eslint-disable-line
              callback(res.Result);
          }
          catch (e) {
            console.log(e);
          }
        }
        else {
          try {
            alert(res.Message);
            if (typeof (eval(errorback)) == "function") // eslint-disable-line
              errorback();
          }
          catch (e) {
            console.log(e);
          }
        }
      },
      error: function () {
        alert('请求失败！');
      }
    });
  };
  // Get请求扩展
  $$.jsonResultGetHandle = function (url, data, callback, errorback) {
    $$.ajax({
      async: true,
      cache: false,
      dataType: 'json',
      url: url,
      data: data,
      type: 'GET',
      success: function (res) {
        if (res.StatusCode == 1) {  // eslint-disable-line
          try {
            if (typeof (eval(callback)) == "function")  // eslint-disable-line
              callback(res.Result);
          }
          catch (e) {
            console.log(e);
          }
        }
        else {
          try {
            alert(res.Message);
            if (typeof (eval(errorback)) == "function") // eslint-disable-line
              errorback();
          }
          catch (e) {
            console.log(e);
          }
        }
      },
      error: function () {
        alert('请求失败！');
      }
    });
  };
});