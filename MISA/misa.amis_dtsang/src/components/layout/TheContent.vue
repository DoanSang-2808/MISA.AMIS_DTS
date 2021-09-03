<template>
    <div class="content">
        <EmployeeList />
    </div>
</template>

<script>
import EmployeeList from '../views/employee/EmployeeList.vue'
export default {
    name: "TheContent",
    components: { EmployeeList}
}
</script>

><style scoped>
.content{
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    /* width: calc(100% - 178px);
    height: calc(100% - 48px);
    padding: 0 20px 0 20px;
    background-color: #eeeeee; */
}
</style>
