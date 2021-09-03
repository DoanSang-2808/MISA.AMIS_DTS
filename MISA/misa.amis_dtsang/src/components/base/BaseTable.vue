<template>
  <table >
    <thead>
      <tr>
        <th style="width: 50px" class="wrapper-checkbox fix">
          <div class="check-box">
            <div class="main-check"></div>
          </div>
        </th>
        <th
          v-for="item of tableHeader"
          :key="item.id"
          :style="{ width: item.columnWidth + 'px' }"
          :class="[item.textTable, item.position]"
        >
          {{ item.columnName }}
        </th>
        <th style="width: 150px" colspan="2">CHỨC NĂNG</th>
      </tr>
    </thead>
    <tbody >
      <tr v-for="employee of employees" :key="employee.id">
        <td style="width: 50px" class="wrapper-checkbox fix">
          <div class="check-box">
            <div class="main-check"></div>
          </div>
        </td>
        <td
          v-for="item of tableHeader"
          :key="item.id"
          :style="{ width: item.columnWidth + 'px' }"
          :class="[item.textTable, item.position]"
        >
          {{ formatData(item.propertyName, employee[item.propertyName]) }}
        </td>
        <td style="padding: 0; text-align: right; border-right: none">
          <div class="btn-edit" @click="btnEditOnclick(employee.employeeId)">
            <p>Sửa</p>
          </div>
        </td>
        <td class="fix-end wrapper-dropdown" style="width: 150px; z-index: 1">
          <div class="context-menu">
            <div class="dropdown">
              <div class="drop"></div>
            </div>
          </div>
          <div class="drop-menu" style="position: absolute; z-index: 2">
            <div
              class=""
              href="#"
              @click="
                btnDuplicationOnclick(
                  employee.employeeId,
                )
              "
            >
              Nhân bản
            </div>
            <div
              class=""
              href="#"
              @click="
                btnDeleteOnclick(employee.employeeId, employee.employeeCode)
              "
            >
              Xóa
            </div>
          </div>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import moment from "moment";
import { formatGender } from "../../js/common.js";
export default {
  name: "Table",
  components: {},
  data() {
    return {
      isActive: {
        type: String,
        default: true,
      },
    };
  },
  props: {
    tableHeader: {
      type: Array,
    },
    employees: {
      type: Array,
    },
  },
  methods: {
    /**
     * Hàm định dạng lại dữ liệu trên bảng
     * Author: DTsang(29/08)
     */
    formatData(property, value) {
      let result = "";
      switch (property) {
        case "dateOfBirth":
          result = value !== null ? moment(value).format("DD/MM/YYYY") : "";
          break;
        case "identityDate":
          result = value !== null ? moment(value).format("DD/MM/YYYY") : "";
          break;
        case "gender":
          result = formatGender(value);
          break;
        default:
          result = value;
          break;
      }
      return result;
    },
    /**
     * Hàm bắt sự kiện khi bấm vào Sửa
     * Author: DTsang(31/08)
     */
    btnEditOnclick(employeeId) {
      this.$emit("editEmployee", employeeId);
    },
    /**
     * Hàm bắt sự kiện khi bấm vào Xóa
     * Author: DTSang(01/09)
     */
    btnDeleteOnclick(employeeId, employeeCode) {
      this.$emit("deleteEmployee", [employeeId, employeeCode]);
    },
    /**
     * Hàm bắt sự kiện khi bấm vào Nhân bản
     * Author: DTSang(01/09)
     */
    btnDuplicationOnclick(employeeId) {
      this.$emit("duplicationEmployee", employeeId);
    },
  },
};
</script>

<style scoped>
table {
  position: relative;
  width: 100%;
  color: #212529;
  table-layout: fixed;
  border-collapse: collapse;
  font-family: Misa-Regular;
}
table th {
  padding: 0.75rem;
  padding-left: 10px;
  position: sticky;
  top: 0;
  z-index: 1;
  background-color: #e5e5e5;
  border-bottom: 1px solid #ccc;
  border-right: 1px solid #ccc;
}
table td {
  padding: 0.75rem;
  padding-left: 10px;
  border-bottom: 1px solid #ccc;
  border-right: 1px dotted #ccc;
  overflow: hidden;
  text-overflow: ellipsis;
}
table thead th {
  border-bottom: 1px solid #dee2e6;
}
.fix {
  position: sticky;
  left: 0;
  z-index: 2;
  border-right: none;
}
.fix50 {
  position: sticky;
  left: 50px;
  z-index: 2;
  border-right: none;
}
.fix193 {
  position: sticky;
  left: 193px;
  z-index: 2;
}
table tbody tr .fix {
  background-color: #fff;
  z-index: 1;
}
table tbody tr .fix50 {
  background-color: #fff;
  z-index: 1;
}
table tbody tr .fix193 {
  background-color: #fff;
  z-index: 1;
}
table tbody tr .fix-end {
  background-color: #fff;
  z-index: 1;
}
.text-left {
  text-align: left;
}
.text-center {
  text-align: center;
}
.check-box {
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}
.main-check {
  border: 1px solid #bbb;
  width: 20px;
  height: 20px;
}
.context-menu {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: start;
  align-items: center;
}
.context-menu .dropdown {
  width: 40px;
  height: 24px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.drop {
  width: 16px;
  height: 16px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -896px -359px;
}
.context-menu .dropdown:hover {
  border: 1px solid rgba(39, 128, 245, 0.87);
}
.drop-menu {
  display: none;
  background-color: #fff;
  border: 1px solid #ccc;
  width: 150px;
  right: 10px;
}
.drop-menu div {
  height: 40px;
  line-height: 40px;
  text-align: center;
}
.drop-menu div:hover {
  background-color: #ccc;
}
.wrapper-dropdown:hover .drop-menu {
  display: block;
}
.btn-edit {
  color: rgba(39, 128, 245, 0.87);
}
.btn-edit p {
  margin: 0;
}
.btn-edit p:hover {
  cursor: pointer;
  text-decoration-line: underline;
}
</style>