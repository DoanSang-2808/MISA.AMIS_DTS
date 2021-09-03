import Vue from 'vue'
import VueRoute from 'vue-router'
import Employee from '../views/employee/EmployeeList'
Vue.use(VueRoute)
const MISAroutes = [
    {
        path: '/',
        name: 'Home',
        component: Employee, 
    },
    {
        path: '/employee',
        name: 'Employee',
        component: () => import('../views/employee/EmployeeList'),    
    },
]
const router = new VueRoute({
    mode: 'history',
    base: process.env.BASE_URL,
    routes:MISAroutes

})
export default router