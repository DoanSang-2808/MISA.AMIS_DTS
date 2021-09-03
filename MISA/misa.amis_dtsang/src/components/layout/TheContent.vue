<template>
    <!-- <div class="content"> -->
        <!-- <EmployeeList />  -->
        <router-view></router-view>
    <!-- </div> -->
</template>

<script>
//import EmployeeList from '../views/employee/EmployeeList.vue'
export default {
    name: "TheContent",
    components: {}
}
</script>

<style scoped>
.content{
    position: absolute;
    top: 48px;
    left: 178px;
    width: calc(100% - 178px);
    height: calc(100% - 48px);
}
</style>
