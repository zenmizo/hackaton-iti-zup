//
//  ViewController.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 04/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import UIKit
import BeagleUI

class ViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }
    
    override func viewDidAppear(_ animated: Bool) {
        openListProducts()
    }

    
    private func openListProducts() {
        
        let listProductViewController = BeagleScreenViewController(
            viewModel: .init(screenType: .remote(BeagleSetting.Routes.buy.path,
                                                 fallback: nil))
        )
        
//        let listProductViewController = BeagleScreenViewController(
//            viewModel: .init(screenType: .declarative(ResultOperationScreen().createScreen()))
//        )
        
        self.navigationController?.pushViewController(listProductViewController, animated: true)
    }

}

