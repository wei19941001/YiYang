// ��ȡurl�еĲ���
function getUrlParam(name) {
  var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //����һ������Ŀ�������������ʽ����
  var r = window.location.search.substr(1).match(reg);  //ƥ��Ŀ�����
  if (r != null) return unescape(r[2]); // eslint-disable-line
  return null; //���ز���ֵ
}

// ���/�޸�url�в�����ֵ
function setUrlParam(name, val) {
  var $thisURL = document.location.href;
  // ���url�а���������������޸�
  if ($thisURL.indexOf(name + '=') > 0) {
    var v = getUrlParam(name);
    if (v != null) {  // eslint-disable-line
      $thisURL = $thisURL.replace(name + '=' + v, name + '=' + val);
    }
    else {
      $thisURL = $thisURL.replace(name + '=', name + '=' + val);
    }
  }
  // ��������������������
  else {
    if ($thisURL.indexOf("?") > 0) {
      $thisURL = $thisURL + "&" + name + "=" + val;
    }
    else {
      $thisURL = $thisURL + "?" + name + "=" + val;
    }
  }
  window.location.href = $thisURL;
}

// ����ת�ַ�
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
// �ַ�ת����
String.prototype.toDate = function () {
  var temp = this.toString();
  temp = temp.replace(/-/g, "/");
  var date = new Date(Date.parse(temp));
  return date;
};
// Json�ַ�ת����
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
// ������չ
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
// ȥ��
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
// ȥ������
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
// ��ʼ������
$(function () {
  // Ƥ���л�
  var $skinState = $.cookie('adminlte_skin');
  if ($skinState)
    $('body').addClass($skinState);
  $('.list-unstyled').on('click', '.full-opacity-hover', function () {
    var $skinSet = $(this).data('skin');
    $.cookie('adminlte_skin', $skinSet);
    $('body').attr('class', function () {
      return $(this).attr('class').replace(/skin\S*/g, '');
    });
    $('body').addClass($skinSet);
  });
  // ���������
  var $sidebarState = $.cookie('adminlte_sidebar');
  if ($.cookie('adminlte_sidebar') == 'collapse') // eslint-disable-line
    $('body').addClass('sidebar-collapse');
  else
    $('body').removeClass('sidebar-collapse');
  $('body').on('click', '.sidebar-toggle', function () {
    if ($sidebarState)
      $.removeCookie('adminlte_sidebar');
    else
      $.cookie('adminlte_sidebar', 'collapse');
  });
  // ����ѡ��
  var $pthName = window.location.pathname.toLowerCase();
  $.each($('.main-sidebar .sidebar-menu').find('a'), function () {
    var $actStr = $(this).attr('href');
    if ($actStr) {
      if ($actStr == '#') // eslint-disable-line
        return;
      if ($actStr.indexOf('?') > 0)
        $actStr = $actStr.substring(0, $actStr.indexOf('?'));
      $actStr = $actStr.toLowerCase();
      if ($actStr == $pthName) {  // eslint-disable-line
        $(this).parent('li').addClass('active').siblings('li').removeClass('active');
      }
    }
  });
  // չʾͼƬ
  $('.thumb').each(function () {
    var url = $(this).data('src');
    $(this).css({ 'background-image': 'url(' + url + ')' });
    $(this).on('click', function () {
      $('#ImageZoom').attr('src', url);
      $('#ImageModal').modal();
    });
  });
  $('#ImageModal').on('hidden.bs.modal', function (e) {
    $('#ImageZoom').attr('src', '');
  });
  // ����ѡ����֧������
  $.fn.datepicker.dates.cn = {
    days: ["����", "��һ", "�ܶ�", "����", "����", "����", "����", "����"],
    daysShort: ["��", "һ", "��", "��", "��", "��", "��", "��"],
    daysMin: ["��", "һ", "��", "��", "��", "��", "��", "��"],
    months: ["һ��", "����", "����", "����", "����", "����", "����", "����", "����", "ʮ��", "ʮһ��", "ʮ����"],
    monthsShort: ["һ��", "����", "����", "����", "����", "����", "����", "����", "����", "ʮ��", "ʮһ��", "ʮ����"],
    today: "����",
    clear: "���",
    titleFormat: "yyyy��MM"
  };
  $.fn.datepicker.defaults.language = 'cn';
  // �첽�ύ��
  $.fn.ajaxSubmitForm = function (callback, errorback) {
    var $formEle = $(this);
    // �ύ
    $.ajax({
      async: true,
      cache: false,
      type: $formEle.attr('method'),
      url: $formEle.attr('action'),
      data: $formEle.serialize(),
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
        alert('����ʧ�ܣ�');
      }
    });
  };
  // Post������չ
  $.jsonResultPostHandle = function (url, data, callback, errorback) {
    $.ajax({
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
        alert('����ʧ�ܣ�');
      }
    });
  };
  // Get������չ
  $.jsonResultGetHandle = function (url, data, callback, errorback) {
    $.ajax({
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
        alert('����ʧ�ܣ�');
      }
    });
  };
});

$(function () {
  $('#waiting-mark').css({ 'width': $(document).width() + 'px', 'height': $(document).height() + 'px' });
  $(window).resize(function () {
    $('#waiting-mark').css({ 'width': $(document).width() + 'px', 'height': $(document).height() + 'px' });
  });
  setTimeout(function () {
    $('#waiting-mark').hide();
  }, 800);
});