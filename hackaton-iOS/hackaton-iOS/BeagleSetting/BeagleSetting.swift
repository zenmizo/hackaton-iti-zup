//
//  BeagleSetting.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 04/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import Foundation


struct BeagleSetting {
    
    enum Routes: String {
        
        case listProducts = "list/product"
        case productDescription = "product?sku_product="
        case buy = "buy/products"
        
        var path: String {
            
//            let address = "http://192.168.0.106:8080"
            let address = "http://localhost:8080"
            return "\(address)/\(self.rawValue)"
        }
    }
    
}
