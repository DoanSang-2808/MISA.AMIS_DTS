import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import VueAxios from "vue-axios"
import DatePicker from 'vue2-datepicker';
import 'vue2-datepicker/index.css';
import Toast from "vue-toastification";
import "vue-toastification/dist/index.css";
import { ValidationProvider, ValidationObserver, extend } from 'vee-validate'; 
import * as rules from 'vee-validate/dist/rules';
import { messages } from 'vee-validate/dist/locale/vi.json';
import Paginate from 'vuejs-paginate'
import router from './components/route/index.js' 


Object.keys(rules).forEach(rule => {
  extend(rule, {
    ...rules[rule], // copies rule configuration
    message: messages[rule] // assign message
  });
});
// Register it globally
Vue.component('ValidationProvider', ValidationProvider);
Vue.component('ValidationObserver', ValidationObserver);

Vue.use(VueAxios, axios)
const options = {
  position: 'bottom-right'
};
Vue.use(Toast, options);
Vue.component('datepicker', DatePicker);
Vue.component('paginate', Paginate)
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
