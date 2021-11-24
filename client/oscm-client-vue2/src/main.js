import Vue from 'vue';
import App from './App.vue';

import ElementUI from 'element-ui';

// import store from './store';
// import router from './router';

Vue.config.productionTip = false;

// set ElementUI lang to EN
// Vue.use(ElementUI, { locale })
// 如果想要中文版 element-ui，按如下方式声明
Vue.use(ElementUI)

new Vue({
  // router,
  // store,
  render: h => h(App),
}).$mount('#app');
