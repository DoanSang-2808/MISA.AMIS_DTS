<template>
  <div>
    <div class="over" :class="{ showDialog: isShow }"></div>
    <div class="employee-list">
      <div class="header-list">
        <div header-title><h4>Nhân viên</h4></div>
        <Button
          typeBtn="add"
          textBtn="Thêm nhân viên mới"
          @btnOnclick="btnOnclick"
        />
      </div>
      <div class="main-list">
        <div class="main-list-top">
          <div class="wrapper">
            <div
              class="export"
              data-toggle="tooltip"
              data-placement="top"
              title="Xuất dữ liệu"
              @click="exportData"
            ></div>
            <div
              class="reload"
              data-toggle="tooltip"
              data-placement="top"
              title="Tải lại trang"
              @click="reloadTable"
            ></div>
            <Input :keySearch="keySearch" @keySearchChange="keySearchChange" />
          </div>
        </div>
        <div class="main-list-bottom">
          <div style="width: 100%; height: 100%">
            <div class="scroll">
              <div class="loading" :class="{isLoading: isLoading}">
                <img src="../../../assets/loading.svg" alt="">
              </div>
              <Table
                :tableHeader="tableHeader"
                :employees="employees"
                @editEmployee="editEmployee"
                @deleteEmployee="deleteEmployee"
                @duplicationEmployee="duplicationEmployee"
              />
            </div>
            <div class="paging">
              <div class="total-record">
                Tổng số: <b>{{ this.totalRecord }}</b> bản ghi
              </div>
              <div class="page-index">
                <div class="page-number">
                  <paginate
                    :page-count="this.totalPage"
                    :page-range="2"
                    :margin-pages="2"
                    :click-handler="clickCallback"
                    :prev-text="'Trước'"
                    :next-text="'Sau'"
                    :container-class="'pagination'"
                    :page-class="'page-item'"
                    :page-link-class="'text-color-black'"
                    :prev-class="'page-pre'"
                    :next-class="'page-next'"
                    :prev-link-class="'text-color-black'"
                    :next-link-class="'text-color-black'"
                  >
                  </paginate>
                </div>
                <div class="option-record">
                  <div class="item-option" :class="{ showDialog: isOpen }">
                    <div class="item" id="10" @click="chooseItem">
                      10 bản ghi trên 1 trang
                    </div>
                    <div class="item" id="20" @click="chooseItem">
                      20 bản ghi trên 1 trang
                    </div>
                    <div class="item" id="30" @click="chooseItem">
                      30 bản ghi trên 1 trang
                    </div>
                    <div class="item" id="50" @click="chooseItem">
                      50 bản ghi trên 1 trang
                    </div>
                    <div class="item" id="100" @click="chooseItem">
                      100 bản ghi trên 1 trang
                    </div>
                  </div>
                  <div class="main-option" :class="{ borderGreen: isOpen }">
                    <div class="main-option-text">
                      <input type="text" :value="pageSizeText" />
                    </div>
                    <div class="main-option-icon" @click="choosePageSize">
                      <div class="icon-mi"></div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <EmployeeDetail
      ref="EmployeeDetail"
      @closeForm="closeForm"
      @reloadTable="reloadTable"
    />
    <PopUpDelete
      ref="PopUpDelete"
      @closePopUpDelete="closePopUp"
      @comfirm="comfirm"
    />
  </div>
</template>

<script>
import Button from "../../base/BaseButton.vue";
import Input from "../../base/BaseInput.vue";
import Table from "../../base/BaseTable.vue";
import EmployeeDetail from "./EmployeeDetail.vue";
import PopUpDelete from "../../base/BasePopUpDelete.vue";
import axios from "axios";
export default {
  name: "EmployeeList",
  components: { Button, Input, Table, EmployeeDetail, PopUpDelete },
  data() {
    return {
      tableHeader: [
        {
          columnName: "MÃ NHÂN VIÊN",
          propertyName: "employeeCode",
          textTable: "text-left",
          position: "fix50",
          columnWidth: 143,
        },
        {
          columnName: "TÊN NHÂN VIÊN",
          propertyName: "fullName",
          textTable: "text-left",
          position: "fix193",
          columnWidth: 250,
        },
        {
          columnName: "GIỚI TÍNH",
          propertyName: "gender",
          textTable: "text-left",
          columnWidth: 105,
        },
        {
          columnName: "NGÀY SINH",
          propertyName: "dateOfBirth",
          textTable: "text-center",
          columnWidth: 150,
        },
        {
          columnName: "SỐ CMND",
          propertyName: "identityNumber",
          textTable: "text-left",
          columnWidth: 250,
        },
        {
          columnName: "NƠI CẤP",
          propertyName: "identityPlace",
          textTable: "text-left",
          columnWidth: 150,
        },
        {
          columnName: "NGÀY CẤP",
          propertyName: "identityDate",
          textTable: "text-center",
          columnWidth: 150,
        },
        {
          columnName: "CHỨC DANH",
          propertyName: "positionName",
          textTable: "text-left",
          columnWidth: 250,
        },
        {
          columnName: "TÊN ĐƠN VỊ",
          propertyName: "departmentName",
          textTable: "text-left",
          columnWidth: 250,
        },
        {
          columnName: "EMAIL",
          propertyName: "email",
          textTable: "text-left",
          columnWidth: 250,
        },
        {
          columnName: "SĐT DI ĐỘNG",
          propertyName: "phoneNumber",
          textTable: "text-center",
          columnWidth: 150,
        },
        {
          columnName: "SĐT CỐ ĐỊNH",
          propertyName: "landlineNumber",
          textTable: "text-center",
          columnWidth: 150,
        },
        {
          columnName: "ĐỊA CHỈ",
          propertyName: "address",
          textTable: "text-left",
          columnWidth: 200,
        },
        {
          columnName: "SỐ TÀI KHOẢN",
          propertyName: "bankAccount",
          textTable: "text-left",
          columnWidth: 150,
        },
        {
          columnName: "TÊN NGÂN HÀNG",
          propertyName: "bankName",
          textTable: "text-left",
          columnWidth: 200,
        },
        {
          columnName: "CN NGÂN HÀNG",
          propertyName: "bankBranch",
          textTable: "text-left",
          columnWidth: 200,
        },
      ],
      employees: [],
      typeBtn: "",
      employee: {},
      employeeDelId: "",
      employeeDelCode: "",
      isShow: false,
      isOpen: false,
      isLoading: false,
      pageSizeText: "20 bản ghi trên 1 trang",
      pageSize: 20,
      pageIndex: 1,
      keySearch: "",
      totalRecord: 0,
      totalPage: 0,
    };
  },
  created() {
    this.loadTable();
  },
  methods: {
    /**
     * Hàm gọi Api lấy dữ liệu cho bảng nhân viên
     * Author: DtSang(29/08)
     */
    loadTable() {
      let self = this;
      self.isLoading= true,
      axios
        .get(
          `https://localhost:5001/api/v1/Employees/Pagging?keySearch=${this.keySearch}&pageIndex=${this.pageIndex}&pageSize=${this.pageSize}`
        )
        .then((response) => {
          self.employees = response.data.data.employees;
          self.totalRecord = response.data.data.totalRecord;
          self.totalPage = response.data.data.totalPage;
          self.isLoading= false;
          console.log(response.data.data.employees);
        })
        .catch((error) => {
          console.log(error);
        });
    },
    /**
     * Cập nhập giá trị type khi 1 trong các button được bấm
     */
    btnOnclick(data) {
      this.typeBtn = data;
    },
    /**
     * Sự kiện đóng form chi tiết
     * Author: DtSang(31/08)
     */
    closeForm() {
      this.isShow = false;
      this.typeBtn = "";
    },
    /**
     * Sự kiện tải lại dữ liệu của bảng
     * Author: DTSang(31/08)
     */
    reloadTable() {
      this.keySearch = "";
      this.pageSize = 20;
      this.pageIndex = 1;
      this.pageSizeText = "20 bản ghi trên 1 trang"; 
      this.loadTable();
    },
    /**
     * Bắt sự kiện sửa nhân viên từ component Table
     * Author: DTSang(31/08)
     */
    async editEmployee(data) {
      this.employee = await this.getEmployeeById(data);
      this.typeBtn = "edit";
      //debugger; // eslint-disable-line
    },
    /**
     * Hàm lấy nhân viên theo id
     * Author: DTSang(31/08)
     */
    getEmployeeById(id) {
      return new Promise((res) => {
        axios
          .get(`https://localhost:5001/api/v1/Employees/${id}`)
          .then((response) => {
            res(response.data.data);
            console.log(response.data.data);
          })
          .catch((error) => {
            console.log(error);
          });
      });
    },
    /**
     * Sự kiện bấm vào nút xóa
     * Author: DTSang(31/08)
     */
    deleteEmployee(data) {
      this.employeeDelId = data[0];
      this.employeeDelCode = data[1];
      this.isShow = true;
      this.$refs.PopUpDelete.openPopupDelete(`<${this.employeeDelCode}>`);
    },
    /**
     * Sự kiện bấm nút đóng pop up Xóa
     * Author: DTSang(31/08)
     */
    closePopUp() {
      this.isShow = false;
      this.employeeDelId = "";
      this.employeeDelCode = "";
    },
    /**
     * Sự kiện bấm vào nút xác nhận xóa trong pop up
     * Author: DTSang(31/08)
     */
    comfirm() {
      let self = this;
      axios
        .delete(`https://localhost:5001/api/v1/Employees/${this.employeeDelId}`)
        .then((response) => {
          this.reloadTable();
          self.$toast.success(response.data.userMsg, {
            timeout: 3000,
          });
          this.closePopUp();
        })
        .catch((error) => {
          console.log(error);
        });
    },
    /**
     * Sự kiện bấm vào nút nhân bản
     * Author: DTSang(01/09)
     */
    async duplicationEmployee(data) {
      this.employee = await this.getEmployeeById(data);
      this.typeBtn = "dup";
    },
    /**
     * Sự kiện bấm nút xuất dữ liệu ra file Excel
     * Author: DTSang(01/09)
     */
    exportData() {
      var self = this;
      axios
        .get(`https://localhost:5001/api/v1/Employees/Export`)
        .then((response) => {
          self.$toast.success(response.data.userMsg, {
            timeout: 3000,
          });
        })
        .catch((error) => {
          console.log(error);
        });
    },
    /**
     * Bắt sự kiện clcik chọn page Size
     * Author: DTSang(02/09)
     */
    choosePageSize() {
      this.color = "#35bf22";
      this.isOpen = !this.isOpen;
    },
    /**
     * Bất sự kiện chọn item thay đổi pageSize
     * Author: DTSang(02/09)
     */
    chooseItem(event) {
      let element = event.target;
      this.pageSizeText = element.textContent;
      this.pageSize = element.getAttribute("id");
      this.isOpen = false;
      this.loadTable();
    },
    /**
     * Hứng thay đổi của keySearch
     * Author: DTsang(02/09)
     */
    keySearchChange(key) {
      this.keySearch = key;
      this.loadTable();
    },
    /**
     * Sự kiệm bấm chuyển trang
     * Author: DTSang(02/09)
     */
    clickCallback(pageNum) {
      console.log(pageNum);
      this.pageIndex = pageNum;
      this.loadTable();
    },
  },
  watch: {
    /**
     * Hàm lắng nghe thay đổi giá trị typeBtn
     * author: DTSang(31/08)
     */
    typeBtn: function () {
      if (this.typeBtn != "") {
        if (this.typeBtn == "add") {
          this.employee = {};
        }
        this.isShow = true;
        this.$refs.EmployeeDetail.showEmployeeDetail(
          this.employee,
          this.typeBtn
        );
      }
    },
  },
};
</script>

<style scoped>
@import url("../../../css/pagination.css");
.over {
    display: none;
    background: #bbb;
    width: 100vw;
    height: 100vh;
    position: absolute;
    top: 0px;
    left: 0;
    opacity: 0.5;
    z-index: 4;
  }
  .showDialog {
    display: block !important;
  }
  .employee-list {
    position: absolute;
    top: 48px;
    left: 178px;
    width: calc(100% - 178px);
    height: calc(100% - 48px);
    padding: 0 20px 0 20px;
    background-color: #eeeeee;
  }
  .header-list {
    width: 100%;
    height: 10%;
    padding: 24px 0 24px 0;
    display: flex;
    justify-content: space-between;
    align-items: center;
    font-family: Misa-Bold;
  }
  .main-list {
    width: 100%;
    height: 90%;
    background-color: #fff;
  }
  .main-list-top {
    width: 100%;
    height: 10%;
    padding: 16px 16px 10px 16px;
  }
  .main-list-top .wrapper {
    display: flex;
    flex-direction: row-reverse;
    align-items: center;
    height: 32px;
  }
  .reload {
    width: 24px;
    height: 24px;
    margin: 0 16px 0 16px;
    background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -425px -201px;
  }
  .reload:hover {
    width: 24px;
    height: 24px;
    margin: 0 16px 0 16px;
    background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -1098px -89px;
  }
  .export {
    width: 24px;
    height: 24px;
    background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -705px -202px;
  }
  .export:hover {
    width: 24px;
    height: 24px;
    background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -1265px -90px;
  }
  .main-list-bottom {
    width: 100%;
    height: 90%;
    padding: 0px 20px 0px 16px;
  }
  .scroll {
    position:relative;
    width: 100%;
    height: 93%;
    margin: 0;
    overflow: auto;
    /* background-color: #ccc; */
  }
  .scroll::-webkit-scrollbar {
    width: 6px;
    height: 6px;
  }
  .scroll::-webkit-scrollbar-track {
    -webkit-box-shadow: inset 0 0 0 #ffffff;
    background: #fff;
    border: 0 solid #000;
  }
  ::-webkit-scrollbar-thumb {
    -webkit-box-shadow: inset 0 0 0 #ffffff;
    background: #bbb;
    border-radius: 4px 4px 4px 4px;
  }
  .loading{
    width: 100%;
    height: 100%;
    position: absolute;
    top : 0;
    background-color: #ccc;
    opacity: 0.5;
    z-index: 5;
    display: none;
  }
  .isLoading{
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .paging {
    position: sticky;
    bottom: 0;
    left: 0;
    right: 0;
    z-index: 1;
    height: 7%;
    background-color: #fff;
    display: flex;
    justify-content: space-between;
    align-items: center;
    font-family: Misa-Regular;
  }
  .page-index {
    width: 70%;
    height: 100%;
    display: flex;
    flex-direction: row-reverse;
    align-items: center;
  }
  .page-number {
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .pagination {
    margin: 0;
  }
  .page-index .option-record {
    height: 70%;
  }
  .page-index .option-record .main-option {
    width: 200px;
    height: 100%;
    margin: 0 16px;
    display: flex;
    align-items: center;
    border: 1px solid #bbb;
  }
  .page-index .option-record .main-option .main-option-text {
    width: 100%;
    height: 100%;
    display: flex;
    align-items: center;
  }
  .page-index .option-record .main-option .main-option-text input {
    font-size: 14px;
    margin-left: 8px;
    outline: none;
    border: none;
    width: 90%;
    height: 100%;
  }
  .page-index .option-record .main-option .main-option-icon {
    height: 100%;
    width: 30px;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .page-index .option-record .main-option .main-option-icon .icon-mi{
    width: 10px;
    height: 10px;
    background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -371px -364px;
  }
  .page-index .option-record .main-option .main-option-icon:hover {
    background-color: #bbb;
  }
  .page-index .option-record .item-option {
    background-color: #fff;
    position: absolute;
    bottom: 45px;
    width: 200px;
    border: 1px solid #ccc;
    margin: 0 16px;
    font-size: 14px;
    text-align: left;
    display: none;
  }
  .borderGreen {
    border-color: #35bf22 !important;
  }
  .page-index .option-record .item-option .item {
    padding: 0 8px;
    height: 32px;
    display: flex;
    align-items: center;
  }
  .page-index .option-record .item-option .item:hover {
    background-color: #ccc;
  }
</style>