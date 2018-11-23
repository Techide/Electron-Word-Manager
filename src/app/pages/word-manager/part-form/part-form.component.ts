import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { NavigationService } from "src/app/shared/services/navigation.service";

@Component({
  selector: "ewm-part-form",
  templateUrl: "./part-form.component.html",
  styleUrls: ["./part-form.component.scss"]
})
export class PartFormComponent implements OnInit {
  constructor(private navigator: NavigationService) {}

  ngOnInit() {}

  onBackButtonClicked() {
    this.navigator.navigateBack();
  }
}
