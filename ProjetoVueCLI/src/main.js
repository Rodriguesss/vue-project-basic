import Vue from 'vue'
import App from './App.vue'
import VueResource from 'vue-resource'
import router from './router.js'

Vue.config.productionTip = false
Vue.use(VueResource);

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
